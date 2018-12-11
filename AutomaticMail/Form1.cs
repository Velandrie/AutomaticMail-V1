
/*Created by Cemal Acar - NextHorizons*/

/* Automatic Mail Version 1.0 Beta */

using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
namespace AutomaticMail
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        private List<Person> PeopleList = new List<Person>();
        private List<Person> EliminatedPeopleList = new List<Person>();
        private List<Person> ToMailList = new List<Person>();


        //Excel'den mail adresi, şifre, body, subject, receiver mail almak için kullanılacak string değişkenler.
        string mail = "";
        string password = "";
        //Excel Dosyasında konulan şifre
        string excelPassword = "nexthorizons112";


        //Program açıldığında Excel dosyasının path'ini otomatikman bulması için verdiğim path.(Excel dosyası, uygulamanın dosyalarının içinde, bin/debug içerisinde.)
        string path = Environment.CurrentDirectory + "\\Excel File\\Excel_MailList(Rev2)";
        string imgsource = Environment.CurrentDirectory + "\\Excel File\\attachment.png";

        public MainForm()
        {
            InitializeComponent();
            this.listView_name.CheckBoxes = true;

        }

        //Gönder butonuna tıklanması
        private void sendBtn_Click(object sender, EventArgs e)
        {
            //CollectDatForSend metoduna, gönderilecek kişilerin tutulduğu listeyi veriyoruz
            CollectDataForSend(ToMailList);

        }

        //Gönderileceklerin olduğu listenin alınması
        private void CollectDataForSend(List<Person> collectData)
        {
            //Gönderilen liste içerisine bakılarak her bir kişinin kadın ya da erkek olma duruma göre SenMessage metoduna gönderiliyor.
            foreach (var p in collectData)
            {
                if(p.Sex == "Erkek")
                {
                    SendMessage(p.Name + " Bey" + " Merhaba,", p.ReceiverMail, subjectTextBox.Text, bodyTextBox.Text, mail, password);
                }
                else
                    SendMessage(p.Name + " Hanım" + " Merhaba,", p.ReceiverMail, subjectTextBox.Text, bodyTextBox.Text, mail, password);

            }
        }

        // Mesajın ilgili kişinin mail adresine gönderilmesi işlemi. Metod, alıcı maili, mesajı, mesaj başlığını, mailimizin adresini ve şifresini alıyor.
        public void SendMessage(string receiverName, string receiverMail, string subject, string body, string mail, string password)
        {
            try
            {
                
                MailAddress fromAddress = new MailAddress(mail);
                MailAddress toAddress = new MailAddress(receiverMail);
                string fromPassword = password;
                Attachment at = new Attachment(imgsource);
                             

                SmtpClient smtp = new SmtpClient
                {
                    // SMTP üzerinden mesajın gönderilmesi işlemi. Gmail ve Hotmail'e gönderebiliyor, diğerleri için denenmedi.
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (MailMessage message = new MailMessage(fromAddress, toAddress)
                {

                    Subject = subject,
                    Body = "<br><h3>" + receiverName + "<br /> <h3/>" + body

                })
                {
                    message.Attachments.Add(at);
                    message.IsBodyHtml = true;
                    smtp.Send(message);
                    statusListView.Items.Add("Gönderildi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Dosya Seç butonuna tıklama işlemi.
        private void browseBtn_Click(object sender, EventArgs e)
        {
            //Dosya Seç butonuna tıklanınca bir Open File Dialog açılıyor
            OpenFileDialog folder = new OpenFileDialog();

            //Sadece Excel dosyaları görünecek şekilde açılıyor.
            folder.Title = "Excel dosyanızı seçin";
            folder.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";


            if (folder.ShowDialog() == DialogResult.OK)
            {
                //Seçilen dosyanın Path'ı alınarak genel path string'ine yazdırılıyor.
                string sFileName = folder.FileName;
                string[] arrAllFiles = folder.FileNames;
                //Seçilen Excel'den veri çekildikten sonra isimleri gösteren ListView de çağrılıyor.
                path = sFileName;
                nameListviewOnStart();

            }

        }

        //İsimlerin ekranda gösterilmesini sağlayacak ListView metodu. PeopleList listesindenin içindeki bilgileri çekiyor.
        public void nameListviewOnStart()
        {

            //Her çekilen kişiye bakılarak ListView'a isim, soyisim, son mail tarihi ve son görüşme tarihi yazdırılıyor.
            foreach (var p in PeopleList)
            {
                var listItem = new ListViewItem();

                listItem.Text = string.Format("{0} {1}", p.Name, p.SurName);

                if(p.LastMailDate != null)
                {
                    var date = DateTime.Parse(p.LastMailDate);
                    listItem.SubItems.Add(date.ToString("dd/MM/yyyy"));
                }

                if (p.LastMeeting != null)
                {
                    var date = DateTime.Parse(p.LastMeeting);
                    listItem.SubItems.Add(date.ToString("dd/MM/yyyy"));
                }

                listView_name.Items.Add(listItem);
            }
        }

        //Excel'den verilerin çekilerek Person sınıfına yazdırılması işlemi
        private void CollectPeopleInfoFromFile()
        {
            //Excel işlemleri
            Excel.Application xlApp = new Excel.Application();
            //Şifreli Excel dosyası açılırken şifresi girilerek açılıyor.
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Filename: path, Password: excelPassword);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            // Mail ve şifre sabit olarak alınıyor.
            mail = (string)(xlWorksheet.Cells[2, 17] as Excel.Range).Value;
            password = (string)(xlWorksheet.Cells[3, 17] as Excel.Range).Value;
            int rowCount = xlRange.Rows.Count;

            //Şuan için işimize yarayacak toplam 12 sütun içerisine bakılıyor.(notlar, şablonlar vs'ye bakılmıyor)
            int necessaryColumnCount = 12;

            //Satırlara bakılıyor.(1.sayıtırda sütu bilgisi var onun için 2'den başlıyor)
            for (int i = 2; i < rowCount; i++)
            {
                //Her bir satıra teker teker bakılarak ayrı ayrı yaratılan Person'lara çekilen değerler giriliyor
                var p = new Person();
                p.RowId = i;

                //Gerekli olan sütunlara bakılıyor
                for (int j = 1; j <= necessaryColumnCount; j++)
                {
                    var cell = xlRange.Cells[i, j];
                    //Eğer bakılan hücre boşsa, bir sonrakine atlanıyor
                    if (cell == null || cell.Value == null)
                        continue;

                    //Bakılan her bir hücre, kişiye ait özelliklere veriliyor.(isim, soyisim, mail vs.)
                    switch (j)
                    {
                        case 1: p.Name = cell.Value.ToString(); break;
                        case 2: p.SurName = cell.Value.ToString(); break;
                        case 3: p.Sex = cell.Value.ToString(); break;
                        case 4: p.Company = cell.Value.ToString(); break;
                        case 5: p.Sector = cell.Value.ToString(); break;
                        case 6: p.Group = cell.Value.ToString(); break;
                        case 7: p.ReceiverMail = cell.Value.ToString(); break;
                        case 8: p.Phone = cell.Value.ToString(); break;
                        case 9: p.LastMeeting = cell.Value.ToString(); break;
                        case 10: p.MeetingType = cell.Value.ToString(); break;
                        case 11: p.LastMailDate = cell.Value.ToString(); break;
                        case 12: p.Note = cell.Value.ToString(); break;
                    }
                }
                //Yaratılan kişiler teker teker PeopleList'e aktarılıyor.
                PeopleList.Add(p);
            }

            EliminatedPeopleList = PeopleList;

            killAll(xlApp, xlWorksheet, xlWorkbook, xlRange);

            //Açılan Excel dosyalarını tam olarak kapatmadığını gözlemlediğim için processKill metodunu burada da çağırdım.
            processKill();
        }

        //Form load olduğunda otomatik olarak isimleri gösteren ListView'in çağrılması için kullanılan event.
        private void MainForm_Load(object sender, EventArgs e)
        {

            this.StartPosition = FormStartPosition.CenterScreen;

            if (isProcessAlive() && DidProcessClosed())
            {
                processKill();
            }

            //Excel dosyasının path'i bulunamazsa kullanıcıdan "Dosya Seç" butonuna basmasını istiyor.
            try
            {
                //Uygulama açıldığında Kişi Listesi ve Şablon ComboBox dolduruluyor.
                CollectPeopleInfoFromFile();
                nameListviewOnStart();
                comboBoxEnterValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occurs: {ex.Message}");
                //MessageBox.Show("Excel Dosyasını bulamadık, lütfen 'Dosya Seç' butonuna basarak seçin.");
            }

        }

        //TextBox'a yazılan notun önce bir string değişkene aktarılması ve bu değişken yardımıyla writeExcel metoduna aktarılması.
        private void noteSaveBtn_Click(object sender, EventArgs e)
        {
            try
            {


                int var = listView_name.FocusedItem.Index;
                string a = richTextBoxNotes.Text;

                writeExcel(var, a);
            }
            catch
            {
                MessageBox.Show("Listeden bir isim seçmediniz.");
            }
        }

        //Eklenen notun Excel dosyasına yazdırılma işlemini yapan metod.
        public void writeExcel(int i, string note)
        {
            try
            {


                //Excel işlemleri.
                Excel.Application xlApp = new Excel.Application();
                //Şifreli Excel dosyası açılırken şifresi girilerek açılıyor.
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Filename: path, Password: excelPassword);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                // TextView'e eklenen notun ilgili excel dosyasındaki bölüme yazdırılması
                xlRange.Cells[i + 2, 12].Value2 = note.ToString();

                killAll(xlApp, xlWorksheet, xlWorkbook, xlRange);

                //processKill metodunu burada da çağırdım.
                processKill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen açıkta kalan Excel dosyanızı kapatın.");
            }
        }

        //Excel'i kapatan kodların tutulduğu ve bazı parametreler alan metod.
        private void killAll(Excel.Application app, Excel._Worksheet worksheet, Excel.Workbook workbook, Excel.Range range)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(worksheet);
            workbook.Close();
            Marshal.ReleaseComObject(workbook);
            app.Quit();
            Marshal.ReleaseComObject(app);
        }

        //Arka planda çalışan process'lere erişerek, Excel'in bulunup, process'in kapatılmasına yarayan metod.
        public void processKill()
        {
            Process[] _proceses = null;
            _proceses = Process.GetProcessesByName("Excel");
            foreach (Process proces in _proceses)
            {
                proces.Kill();
            }
        }

        //Uygulama içerisinden Excel Dosyasına erişmek için kullanılan button
        private void OpenExcelFileBtn_Click(object sender, EventArgs e)
        {

            //Kullanıcı listView'e tıklayınca eğer arka planda excel işlemi yapıyorsa, kapatması isteniyor.
            if (isProcessAlive())
            {
                MessageBox.Show("Lütfen açık olan Excel dosyanızı kapatınız.");
                return;
            }
            //Excel dosyasının path'ı kullanılıyor
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {

                Process.Start(new ProcessStartInfo(path));
            }
            else
            {
                MessageBox.Show("Excel Dosyasını bulamadık, lütfen 'Dosya Seç' butonuna basarak seçin.");
            }


        }

        //Programda bir event çalışması durumunda, eğer kullanıcı excel'de işlem yapıyorsa çakışma meydana gelmemesi için, excel'in açık olup olmadığını kontrol ediyor
        public bool isProcessAlive()
        {

            return Process.GetProcessesByName("Excel").Length > 0;

        }

        //Arkada çalışan Excel uygulamasının kullanıcıya kapatılıp kapatılmamasını soran Yes - No Dialog
        public bool DidProcessClosed()
        {
            DialogResult dialogResult = MessageBox.Show("Arka planda çalışan Excel dosyaları kapatılsın mı?" +
                " Eğer kapatmamayı seçerseniz uygulama düzgün çalışmayabilir.", "Açık Excel dosyası tespit edildi", MessageBoxButtons.YesNo);

            return dialogResult == DialogResult.Yes;
        }

        //Verilerin listede sıralanması
        private void sortListBtn_Click(object sender, EventArgs e)
        {

            listView_name.Items.Clear();

            //Seçilen ilk checklistBox'da seçilen elemanların EliminateSector metoduna gönderilerek bir değişkene atanması
            var eliminationSectors = EliminateSector(checkedListBox1.CheckedItems);

            //İkinci seçilen CheckListBox2'deki elemanların EliminateGroup metoduna aktarılıp işlemden geçirilerek bir değişkene aktarılması
            var eliminationGroups = EliminateGroup(eliminationSectors, checkedListBox2.CheckedItems);

            //Başarılı bir şekilde süzgeçten geçirilen elemanların ShowEliminatedItems metoduna gönderilerek ekrana bastırılması.
            ShowEliminatedItems(eliminationGroups);
        }

        //Gelen verilen listview'a bastırılması metodu
        private void ShowEliminatedItems(List<Person> people)
        {
            EliminatedPeopleList = people;

            //String.Format ve date fonksiyonlarıyla listview elemanlarının yazdırılması
            foreach (var p in people)
            {
                var listItem = new ListViewItem();

                listItem.Text = string.Format("{0} {1}", p.Name, p.SurName);

                if (p.LastMailDate != null)
                {
                    var date = DateTime.Parse(p.LastMailDate);
                    listItem.SubItems.Add(date.ToString("dd/MM/yyyy"));
                }

                if (p.LastMeeting != null)
                {
                    var date = DateTime.Parse(p.LastMeeting);
                    listItem.SubItems.Add(date.ToString("dd/MM/yyyy"));
                }

                listView_name.Items.Add(listItem);

            }
        }


        //CheckListBox1'de seçili kritere göre List elemanlarının dizilerek geri döndürülmesi
        private List<Person> EliminateSector(CheckedListBox.CheckedItemCollection sectors)
        {
            var people = new List<Person>();
            //Eğer seçili bir eleman yoksa bütün elemanları döndürüyor
            if (sectors.Count == 0)
                return PeopleList;

            foreach(string s in sectors)
            {
                //İlgili sektördeki kişileri içeren dizi (Savunma, Fabrika vs)
                var sectorList = PeopleList.FindAll(p => p.Sector == s);

                //Üstte belirtilen sektördeki dizileri boş olan yeni diziye aktar
                people.AddRange(sectorList);
            }

            return people;
        }

        //CheckListBox2'de seçili kritere göre List elemanlarının dizilerek geri döndürülmesi
        private List<Person> EliminateGroup(List<Person> eliminatedSector, CheckedListBox.CheckedItemCollection groups)
        {
            var people = new List<Person>();

            //Eğer seçili bir grup yoksa bütün sektörde elenenleri döndürüyor.(sektörde seçili yoksa zaten tüm elemanları döndürüyordu)
            if (groups.Count == 0)
                return eliminatedSector;

            foreach (string s in groups)
            {
                //İlgili gruptaki kişileri içeren dizi (1. grup vs)
                var groupList = eliminatedSector.FindAll(p => p.Group == s);

                //Üstte belirtilen gruptaki dizileri boş olan yeni diziye aktar
                people.AddRange(groupList);
            }

            return people;
        }

        //Şablon Combobox'ının içindeği değer değiştikçe, ona karşılık gelen mail body de değişiyor.
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Excel Application, dosya ve uzunluk tanımlama işlemleri
            Excel.Application xlApp = new Excel.Application();
            //Şifreli Excel dosyası açılırken şifresi girilerek açılıyor.
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Filename: path, Password: excelPassword);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            colCount = 14;
            string selected = this.metroComboBox1.GetItemText(this.metroComboBox1.SelectedItem);


            //Excel sütununda içerisinde veri oldukça okumaya devam edecek.
            for (int i = 2; i <= rowCount; i++)
            {
                if (xlRange.Cells[i, colCount] != null && xlRange.Cells[i, colCount].Value2 != null && xlRange.Cells[i, 15].Value2.ToString() == selected)
                {
                    bodyTextBox.Text = xlRange.Cells[i, colCount].Value2.ToString();
                }
            }

            killAll(xlApp, xlWorksheet, xlWorkbook, xlRange);

            //Kapattığından emin olmak için, Excel işlemlerini kapatan metodu burada da çağırdım.
            processKill();

        }

        //Mail Şablonları'nın Excel'den çekilmesi işlemi.
        private void comboBoxEnterValue()
        {
            //Excel Application, dosya ve uzunluk tanımlama işlemleri
            Excel.Application xlApp = new Excel.Application();
            //Şifreli Excel dosyası açılırken şifresi girilerek açılıyor.
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Filename: path, Password: excelPassword);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            colCount = 15;

            //Excel sütununda içerisinde veri oldukça okumaya devam edecek.
            for (int i = 2; i <= rowCount; i++)
            {
                if (xlRange.Cells[i, colCount] != null && xlRange.Cells[i, colCount].Value2 != null)
                {
                    metroComboBox1.Items.Add(xlRange.Cells[i, colCount].Value2.ToString());
                }
            }

            killAll(xlApp, xlWorksheet, xlWorkbook, xlRange);

            //Kapattığından emin olmak için, Excel işlemlerini kapatan metodu burada da çağırdım.
            processKill();
        }

        //Önizleme Labeli (Cemal Bey Merhaba)
        private void FillLabel(List<Person> checkedpeople)
        {
            //Eğer kimse seçilmeden çağrılmışsa metoddan çıkılıyor
            if (checkedpeople.Count == 0)
                return;

            //Listenin en sonundaki kişiye bakılıyor.
            var lastPerson = checkedpeople[checkedpeople.Count - 1];

            //Bakılan kişinin erkek ya da kadın olma durumuna göre önizleme label'ına yazdırılıyor.
            if(lastPerson.Sex =="Erkek")
            {
                mailLabel.Text = lastPerson.Name + " Bey" + " Merhaba";
            }
            else
                mailLabel.Text = lastPerson.Name + " Hanım" + " Merhaba";


        }

        //ListView'da seçilen kişilerin "Gönderilecekler" textbox'ına yazdırılması işlemi
        private void sendeMailtoBtn_Click(object sender, EventArgs e)
        {
            //Seçilenleri tutmak için Person türünde bir list yaratılıyor.
            ToMailList = new List<Person>();

            //Seçilen itemlere teker teker bakılıyor.
            foreach(ListViewItem item in listView_name.CheckedItems)
            {
                //Seçilip seçilmedikleri kontrol ediliyor.
                if (item.Checked)
                {
                    //Zaten elenmiş kişilerin tutulduğu list'deki kişilerin arasından, bir de check edilmişleri bir değişkene aktarılıyor.
                    var selectedPerson = EliminatedPeopleList[item.Index];
                    //Değişkene aktarılan kişi, listeye aktarılıyor.
                    ToMailList.Add(selectedPerson);
                }               
            }
            //Text'e yazılması için bu metod çağırılıyor.
            ShowSendersToText(ToMailList);
            //Önizleme label'ı için yazılan metoda da gönderiliyor.
            FillLabel(ToMailList);
        }

        //ListView'da seçilen(checked) kişiler bu metoda geliyor. 
        private void ShowSendersToText(List<Person> senders)
        {
            //ListView'da kimse seçilmeden "gönderilecekleri seç" butonuna basılırsa ekrana mesaj döndürüyor
            if(senders.Count == 0)
            {
                MessageBox.Show("Lütfen kişi listesinden en az bir kişiyi seçin");
                mailListTextbox.Clear();
                return;
            }

            //Gönderilecekler text'indeki kişiler bir stringe aktarılıyor.
            string text = mailListTextbox.Text;

            //Eğer seçilen kişi zaten önceden seçilmiş ve yazdırılmışsa, bir daha yazdırılmaması için bakılıyor.
            senders.ForEach(p => {
                if (!mailListTextbox.Text.Contains(p.Name) || !mailListTextbox.Text.Contains(p.SurName))
                {
                    text += string.Format("{0} {1}", p.Name, p.SurName); if (text != "")
                        text += "; ";
                }

            });
            
            mailListTextbox.Text = text;
        }

        //Arama TextBox'ın içine değer girilmesi
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            //textbox'a değer giirp sildikten sonra bu döngüye giriyor
            if (searchTxt.Text == "")
            {
                //Öncelikle listview'ın içini boşaltıyor.
                listView_name.Items.Clear();
                //PeopleList'deki değerleri yeniden döndürüyor.
                ShowEliminatedItems(PeopleList);
                return;
            }
            //textbox'ın içine yazdığımız değerleri EliminatedPeopleList'dekiler ile karşılaştırıyor.
            var searchedItems = EliminatedPeopleList.FindAll(p => p.Name.ToLower().StartsWith(searchTxt.Text.ToLower()));
            //Öncelikle listview'ın içini boşaltıyor
            listView_name.Items.Clear();
            //searchedItems'ın içindeki değerleri ShowEliminatedItems metoduna gönderiyoruz.
            ShowEliminatedItems(searchedItems);
        }

        //Gönderilecek mail için resim attachment seçilmesi
        private void setImageLocation_Click(object sender, EventArgs e)
        {
            //Dosya Seç butonuna tıklanınca bir Open File Dialog açılıyor
            OpenFileDialog folder = new OpenFileDialog();

            //Sadece Resim dosyaları görünecek şekilde açılıyor.
            folder.Title = "Eklenecek resim nesnesini seçin";
            folder.Filter = "Image Files|*.jpg;*.jpeg;*.png";


            if (folder.ShowDialog() == DialogResult.OK)
            {
                //Seçilen resmin Path'ı alınarak genel imgsource string'ine yazdırılıyor.
                string imageFileName = folder.FileName;
                string[] arrAllFiles = folder.FileNames;
                imgsource = imageFileName;
            }
        }

        //ListView'de Notunu görmek istediği kişiye çift tıklanılması işlemi
        private void listView_name_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //Kullanıcı listView'e tıklayınca eğer arka planda excel işlemi yapıyorsa, kapatması isteniyor.
                if (isProcessAlive())
                {
                    MessageBox.Show("Lütfen açık olan Excel dosyanızı kapatınız.");
                    return;
                }

                //Excel işlemleri
                Excel.Application xlApp = new Excel.Application();
                //Şifreli Excel dosyası açılırken şifresi girilerek açılıyor.
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Filename: path, Password: excelPassword);

                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                //Tıklanan ismin Index numarasının alınması
                int var = listView_name.FocusedItem.Index;

                //Alınan index ile beraber, o isme karşılık gelen notun Excel dosyasından çekilmesi
                richTextBoxNotes.Text = (xlRange.Cells[var + 2, 12].Value2.ToString());

                killAll(xlApp, xlWorksheet, xlWorkbook, xlRange);

                //Açılan Excel dosyalarını tam olarak kapatmadığını gözlemlediğim için processKill metodunu burada da çağırdım.
                processKill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen açıkta kalan Excel dosyasını kapatın.");
            }
        }

        //Hepsini seç checkBox'ı.
        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox check edildiğinde listview elemanlarının hepsi check ediliyor.
            if (selectAll.Checked)
            {
                for(int i=0; i<= listView_name.Items.Count -1; i++)
                {
                    listView_name.Items[i].Checked = true;
                }

            }
            //checkBox'ın check'i kaldırıldığında listview elemanlarının hepsinin check'i kaldırılıyor.
            else
                for (int i = 0; i <= listView_name.Items.Count-1; i++)
                {
                    listView_name.Items[i].Checked = false;
                }
        }
    }
    

}





