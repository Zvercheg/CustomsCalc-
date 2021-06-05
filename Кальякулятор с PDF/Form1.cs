using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Кальякулятор_с_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void Button1_Click(object sender, EventArgs e)
        {

            float end = 0; //таможня
            float customsNacked = 0;
            int bs = 0; //переменная для просчета таможни


            int costarrive1 = int.Parse(deliverLand.Text); //стоимость доставки Суша
            int costarrive2 = int.Parse(deliverSea.Text); //стоимость доставки Море
            int costarrive = costarrive1 + costarrive2;
            float cost = int.Parse(autocost.Text); //цена авто в США
            var eng = float.Parse(enginee.Text); //объем двигателя
            eng = eng / 1000;
            var yearr = float.Parse(year.Text); //Год
            yearr = 2021 - yearr - 1;

            if (yearr <= 0)
            {
                yearr = 1;
            }
            float port = 0; //Экспедирование
            if (portraz.Text == "")
            {
                port = 450;
            }
            else
            {
                port = float.Parse(portraz.Text);
            }

            float broker; //Таможенный брокер
            if (tamoz.Text == "")
            {
                broker = 300;
            }
            else
            {
                broker = float.Parse(tamoz.Text);
            }

            float stayport; //Стояка в порту США
            
            if (portstay.Text == "")
            {
                stayport = 100;
            }
            else
            {
                stayport = int.Parse(portstay.Text);
            }

            float serf; //Сертификация

            if (sertificat.Text == "")
            {
                serf = 250;
            }
            else
            {
                serf = int.Parse(sertificat.Text);
            }

            //Наша Комиссия
            float ourmoney;
            if (money.Text == "")
            {
                ourmoney = 500;
            }
            else
            {
                ourmoney = int.Parse(money.Text);
            }
            float autoinuckrain; //Цена растаможенного авто в Украине
            float auc1; // 1 таблица на копарте или иншурансе
            float auc2; // 2 таблица на копарте или иншурансе
            float auc = 0; //Аукционный сбор результативный
            float AKS = 0; //Аксциз
            float POSHL = 0; //Пошлина
            float NDS = 0; //НДС
            float PENS = 0; //Пенсионный сбор
            int Mreo;
            if (MREO.Text == "")
            {
                Mreo = 100;
            }
            else
            {
                Mreo = int.Parse(MREO.Text);
            }
            int portOdessaStay;

            if (StayPortOdessa.Text == "")
            {
                portOdessaStay = 40;
            }
            else
            {
                portOdessaStay = int.Parse(StayPortOdessa.Text);
            }

            float insurance = 0; //Страховка на тачку



            if (manualInputAuc.Checked == false)
            {

                //Аукционный сбор  1 таблица
                if (Copart.Checked)
                {
                    if (cost < 100)
                    {
                        auc1 = 1;
                    }
                    else if (cost >= 100 && cost < 200)
                    {
                        auc1 = 25;
                    }
                    else if (cost >= 200 && cost < 300)
                    {
                        auc1 = 50;
                    }
                    else if (cost >= 300 && cost < 400)
                    {
                        auc1 = 75;
                    }
                    else if (cost >= 400 && cost < 500)
                    {
                        auc1 = 110;
                    }
                    else if (cost >= 500 && cost < 550)
                    {
                        auc1 = 125;
                    }
                    else if (cost >= 550 && cost < 600)
                    {
                        auc1 = 130;
                    }
                    else if (cost >= 600 && cost < 700)
                    {
                        auc1 = 140;
                    }
                    else if (cost >= 700 && cost < 800)
                    {
                        auc1 = 155;
                    }
                    else if (cost >= 800 && cost < 900)
                    {
                        auc1 = 170;
                    }
                    else if (cost >= 900 && cost < 1000)
                    {
                        auc1 = 185;
                    }
                    else if (cost >= 1000 && cost < 1200)
                    {
                        auc1 = 200;
                    }
                    else if (cost >= 1200 && cost < 1300)
                    {
                        auc1 = 225;
                    }
                    else if (cost >= 1300 && cost < 1400)
                    {
                        auc1 = 240;
                    }
                    else if (cost >= 1400 && cost < 1500)
                    {
                        auc1 = 250;
                    }
                    else if (cost >= 1500 && cost < 1600)
                    {
                        auc1 = 260;
                    }
                    else if (cost >= 1600 && cost < 1700)
                    {
                        auc1 = 275;
                    }
                    else if (cost >= 1700 && cost < 1800)
                    {
                        auc1 = 285;
                    }
                    else if (cost >= 1800 && cost < 2000)
                    {
                        auc1 = 300;
                    }
                    else if (cost >= 2000 && cost < 2400)
                    {
                        auc1 = 325;
                    }
                    else if (cost >= 2400 && cost < 2500)
                    {
                        auc1 = 335;
                    }
                    else if (cost >= 2500 && cost < 3000)
                    {
                        auc1 = 350;
                    }
                    else if (cost >= 3000 && cost < 3500)
                    {
                        auc1 = 400;
                    }
                    else if (cost >= 3500 && cost < 4000)
                    {
                        auc1 = 450;
                    }
                    else if (cost >= 4000 && cost < 4500)
                    {
                        auc1 = 475;
                    }
                    else if (cost >= 4500 && cost < 5000)
                    {
                        auc1 = 500;
                    }
                    else if (cost >= 5000 && cost < 6000)
                    {
                        auc1 = 525;
                    }
                    else if (cost >= 6000 && cost < 7500)
                    {
                        auc1 = 550;
                    }
                    else if (cost >= 7500 && cost < 10000)
                    {
                        auc1 = 575;
                    }
                    else if (cost >= 10000 && cost < 15000)
                    {
                        auc1 = 600;
                    }
                    else
                    {
                        auc1 = cost / 25;
                    }
                    //Аукционный сбор таблица 2

                    if (cost < 100)
                    {
                        auc2 = 0;
                    }
                    else if (cost >= 100 && cost < 500)
                    {
                        auc2 = 39;
                    }
                    else if (cost >= 500 && cost < 1000)
                    {
                        auc2 = 49;
                    }
                    else if (cost >= 1000 && cost < 1500)
                    {
                        auc2 = 69;
                    }
                    else if (cost >= 1500 && cost < 2000)
                    {
                        auc2 = 79;
                    }
                    else if (cost >= 2000 && cost < 4000)
                    {
                        auc2 = 89;
                    }
                    else if (cost >= 4000 && cost < 6000)
                    {
                        auc2 = 99;
                    }
                    else if (cost >= 6000 && cost < 8000)
                    {
                        auc2 = 119;
                    }
                    else
                    {
                        auc2 = 129;
                    }
                }
                else // If Iaai.Checked
                {
                    if (cost < 100)
                    {
                        auc1 = 1;
                    }
                    else if (cost >= 100 && cost < 200)
                    {
                        auc1 = 40;
                    }
                    else if (cost >= 200 && cost < 300)
                    {
                        auc1 = 60;
                    }
                    else if (cost >= 300 && cost < 350)
                    {
                        auc1 = 75;
                    }
                    else if (cost >= 350 && cost < 400)
                    {
                        auc1 = 90;
                    }
                    else if (cost >= 400 && cost < 500)
                    {
                        auc1 = 100;
                    }
                    else if (cost >= 500 && cost < 600)
                    {
                        auc1 = 130;
                    }
                    else if (cost >= 600 && cost < 700)
                    {
                        auc1 = 145;
                    }
                    else if (cost >= 700 && cost < 800)
                    {
                        auc1 = 160;
                    }
                    else if (cost >= 800 && cost < 900)
                    {
                        auc1 = 175;
                    }
                    else if (cost >= 900 && cost < 1000)
                    {
                        auc1 = 190;
                    }
                    else if (cost >= 1000 && cost < 1100)
                    {
                        auc1 = 205;
                    }
                    else if (cost >= 1100 && cost < 1200)
                    {
                        auc1 = 220;
                    }
                    else if (cost >= 1200 && cost < 1300)
                    {
                        auc1 = 230;
                    }
                    else if (cost >= 1300 && cost < 1400)
                    {
                        auc1 = 240;
                    }
                    else if (cost >= 1400 && cost < 1500)
                    {
                        auc1 = 255;
                    }
                    else if (cost >= 1500 && cost < 1600)
                    {
                        auc1 = 270;
                    }
                    else if (cost >= 1600 && cost < 1700)
                    {
                        auc1 = 290;
                    }
                    else if (cost >= 1700 && cost < 1800)
                    {
                        auc1 = 300;
                    }
                    else if (cost >= 1800 && cost < 2000)
                    {
                        auc1 = 310;
                    }
                    else if (cost >= 2000 && cost < 2200)
                    {
                        auc1 = 325;
                    }
                    else if (cost >= 2200 && cost < 2400)
                    {
                        auc1 = 330;
                    }
                    else if (cost >= 2400 && cost < 2500)
                    {
                        auc1 = 345;
                    }
                    else if (cost >= 2500 && cost < 3000)
                    {
                        auc1 = 360;
                    }
                    else if (cost >= 3000 && cost < 3500)
                    {
                        auc1 = 400;
                    }
                    else if (cost >= 3500 && cost < 4000)
                    {
                        auc1 = 450;
                    }
                    else if (cost >= 4000 && cost < 4500)
                    {
                        auc1 = 475;
                    }
                    else if (cost >= 4500 && cost < 5000)
                    {
                        auc1 = 500;
                    }
                    else if (cost >= 5000 && cost < 6000)
                    {
                        auc1 = 525;
                    }
                    else if (cost >= 6000 && cost < 7500)
                    {
                        auc1 = 550;
                    }
                    else if (cost >= 7500 && cost < 20000)
                    {
                        auc1 = 500 + (cost / 100);
                    }
                    else
                    {
                        auc1 = cost / 25;
                    }
                    //Аукционный сбор таблица 2

                    if (cost < 100)
                    {
                        auc2 = 0;
                    }
                    else if (cost >= 100 && cost < 500)
                    {
                        auc2 = 29;
                    }
                    else if (cost >= 500 && cost < 1000)
                    {
                        auc2 = 39;
                    }
                    else if (cost >= 1000 && cost < 1500)
                    {
                        auc2 = 59;
                    }
                    else if (cost >= 1500 && cost < 2000)
                    {
                        auc2 = 69;
                    }
                    else if (cost >= 2000 && cost < 4000)
                    {
                        auc2 = 79;
                    }
                    else if (cost >= 4000 && cost < 6000)
                    {
                        auc2 = 89;
                    }
                    else if (cost >= 6000 && cost < 8000)
                    {
                        auc2 = 99;
                    }
                    else
                    {
                        auc2 = 119;
                    }
                }
                //ТОЧНАЯ ЦЕНА АВТО ДЛЯ ТАМОЖНИ

                auc = auc1 + auc2 + 109; //Комиссия аукциона
            }
            else
            {
                auc = int.Parse(Auc.Text);
            }


            cost += auc;
            //Расчет страховки тачки
            if (insurance0.Checked)
            {
                insurance = 0;
            }
            else if (cost < 6000)
            {
                insurance = 180;
            }
            else if (!insuranse6.Checked && !insuranse9.Checked)
            {
                
                
                    insurance = cost * 3 / 100;
                
            }
            else
            {
               
                if (insuranse6.Checked)
                {
                    insurance = cost * 6 / 100;
                }
                else if (insuranse9.Checked)
                {
                    insurance = cost * 9 / 100;
                }
               
            }

            cost += 1000;

            //Чекбоксы бензин дизель или электро
            int check = 0;
            if (GAS.Checked)
            {
                check = 1; //бензин
                killmepls.Text = "Gasoline";

            }
            else if (diz.Checked)
            {
                check = 2; //дизель
                killmepls.Text = "diesel";
            }
            else if (hub.Checked)
            {
                check = 3; //гибрид
                killmepls.Text = "hybrid";
            }
            else if (ele.Checked)
            {
                check = 4; //електро
                killmepls.Text = "electro";
            }

            //В зависимости от топлива какая цена при умножении для аксциза



            if (check != 4)
            {
                if (check == 1)
                {
                    if (eng <= 3)
                    {
                        bs = 57;
                    }
                    else if (eng > 3)
                    {
                        bs = 113;
                    }

                }
                else if (check == 2)
                {
                    if (eng <= 7 / 2)
                    {
                        bs = 85;
                    }
                    else if (eng > 7 / 2)
                    {
                        bs = 169;
                    }
                }
                else if (check == 3)
                {
                    if (eng <= 3)
                    {
                        bs = 57;
                    }
                    else if (eng > 3)
                    {
                        bs = 113;
                    }

                }

                //Просчеты



                AKS = bs * yearr * eng; //Акциз
                POSHL = cost / 10; //Пошлина
                NDS = (cost + POSHL + AKS) / 5; //НДС
                if (cost < 12000) // Пенсионный фонд
                {
                    PENS = (cost * 3) / 100;
                }

                else if (cost >= 12000 && cost < 20000)

                {
                    PENS = (cost * 4) / 100;
                }
                else

                {
                    PENS = (cost * 5) / 100;
                }

                end = NDS + POSHL + AKS + PENS; //Чисто за таможню
                customsNacked = end - PENS;
            }
            else if (check == 4)
            {


                AKS = (eng / 10) + eng;
                POSHL = 0;
                NDS = 0;
                if (cost < 12000) // Пенсионный фонд
                {
                    PENS = (cost * 3) / 100;
                }
                else if (cost >= 12000 && cost < 20000)
                {
                    PENS = (cost * 4) / 100;
                }
                else
                {
                    PENS = (cost * 5) / 100;
                }
                // Пенсионный фонд
                end = NDS + POSHL + AKS + PENS; //Чисто за таможню
                customsNacked = end - PENS;
            }

            // auc = auc1 + auc2 + 59; //Комиссия аукциона
            // cost += auc; //добавление к цене аукционного сбор
            //cost += 400; //добавление 400 $ каких-то



            double end2 = Math.Round(end, 0); //Округление
            double insurance1 = Math.Round(insurance, 0);



            cost -= 1000;




            autoinuckrain = Mreo + portOdessaStay + costarrive + port + broker + ourmoney + end + cost + stayport + insurance; //Округление цены авто в Украине
            double autoinuckrain2 = Math.Round(autoinuckrain, 0); //Округление цена авто в Украине
            double endal = autoinuckrain2 + serf;

            double total1 = cost;
            total1 = Math.Round(total1, 0);
            double total2 = costarrive1 + costarrive2 + insurance + stayport + ourmoney;
            total2 = Math.Round(total2, 0);
            double total3 = broker + port + customsNacked + 40;
            total3 = Math.Round(total3, 0);
            double total4 = endal;
            total4 = Math.Round(total4, 0);
            Total1.Text = Convert.ToString(total1);
            Total2.Text = Convert.ToString(total2);
            Total3.Text = Convert.ToString(total3);
            Total4.Text = Convert.ToString(total4);

            //очистка при повторном клике
            result.Clear();
            Pens.Clear();
            aks.Clear();
            poshl.Clear();
            nds.Clear();
            Auc.Clear();
            deliverLand.Clear();
            portraz.Clear();
            tamoz.Clear();
            portstay.Clear();
            sertificat.Clear();
            money.Clear();
            autouk.Clear();
            endall.Clear();
            //Выводы
            double customsNacked1 = Math.Round(customsNacked, 0);
            double PENS1 = Math.Round(PENS, 0);
            inshurance.Text = Convert.ToString(insurance1);
            result.Text = Convert.ToString(customsNacked1); //Вывод только таможни
            Pens.Text = Convert.ToString(PENS1); //Вывод пенсионного
            aks.Text = Convert.ToString(AKS); //Вывод аксциза
            poshl.Text = Convert.ToString(POSHL); //Вывод пошлины
            nds.Text = Convert.ToString(NDS); //Вывод НДС
            Auc.Text = Convert.ToString(auc); //Вывод аукционного сбора
            deliverLand.Text = Convert.ToString(costarrive1); //Вывод цены доставки суша
            deliverSea.Text = Convert.ToString(costarrive2);
            portraz.Text = Convert.ToString(port); //Вывод разгрузки в порту
            tamoz.Text = Convert.ToString(broker); //Вывод цены таможенного брокера
            portstay.Text = Convert.ToString(stayport); //Вывод стоянки в порту
            sertificat.Text = Convert.ToString(serf);//Вывод цены за сертификацию
            money.Text = Convert.ToString(ourmoney); //Вывод нашей комисии
            autouk.Text = Convert.ToString(autoinuckrain2); //Вывод цены расстаможенного авто в Украине
            endall.Text = Convert.ToString(endal);//Вывод общей стоимости
            MREO.Text = Convert.ToString(Mreo); 
            StayPortOdessa.Text = Convert.ToString(portOdessaStay);

        }

        public void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Autocost_TextChanged(object sender, EventArgs e)
        {

        }

        public void Enginee_TextChanged(object sender, EventArgs e)
        {

        }

        public void GAS_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void Year_TextChanged(object sender, EventArgs e)
        {

        }

        private void Result_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void PDF_Click(object sender, EventArgs e)
        {

            using (FileStream outFile = new FileStream("result.pdf", FileMode.Create))
            {
                PdfReader pdfReader1 = new PdfReader(new MemoryStream(File.ReadAllBytes("zero.pdf")));
                PdfStamper pdfStamper = new PdfStamper(pdfReader1, outFile);
                AcroFields fields = pdfStamper.AcroFields;
                string yearcar = Convert.ToString(2020 - Convert.ToInt32(year.Text)); //просчет года авто

                string abc = killmepls.Text;


                fields.SetField("enginetype", abc, true);

                fields.SetField("result", result.Text, true);
                fields.SetField("endall", endall.Text, true);
                fields.SetField("year", yearcar, true);
                fields.SetField("year", yearcar, true);
                fields.SetField("portstay", portstay.Text, true);
                fields.SetField("money", money.Text, true);
                fields.SetField("enginee", enginee.Text, true);



                fields.SetField("autocost", autocost.Text, true);
                fields.SetField("Auc", Auc.Text, true);
                fields.SetField("deliverLand", deliverLand.Text, true);
                fields.SetField("portraz", portraz.Text, true);
                fields.SetField("tamoz", tamoz.Text, true);
                fields.SetField("result", result.Text, true);
                //fields.SetField("money#2", money.Text, true);
                fields.SetField("autouk", autouk.Text, true);
                fields.SetField("portstay", portstay.Text, true);
                fields.SetField("sertificat", sertificat.Text, true);
                fields.SetField("Pens", Pens.Text, true);
                //  pdfStamper.FormFlattening = AnatherOpenDialog;
                ////pizdez




                float X = 407;
                float Y = 815;
                string imageURL = "img.jpg";
                Stream inputImageStream = new MemoryStream(File.ReadAllBytes(imageURL));


                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                image.ScaleToFit(140, 190);
                PdfContentByte content = pdfStamper.GetOverContent(1);
                image.SetAbsolutePosition(X, Y);
                content.AddImage(image, true);
                pdfStamper.Close();

                pdfReader1.Close();
                outFile.Close();
                inputImageStream.Dispose();
                inputImageStream.Close();
                MessageBox.Show(
            "PDF успешно обновлен",
            "Операция успешна",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            }
        }


        private void TextBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ele_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Deliver_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcel_Save_Click(object sender, EventArgs e)
        {
            //Объявляем приложение
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

            //Отобразить Excel
            ex.Visible = true;
            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 1;
            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Open(System.IO.Path.GetFullPath(@"Adrenalin Auto Group.xlsx"),
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Type.Missing, Type.Missing);
            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;
            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
            //Название листа (вкладки снизу)
            sheet.Name = "Рассчет";

            /*Excel.Range range1 = sheet.get_Range(sheet.Cells[6, 4], sheet.Cells[7, 4]);
            Excel.Range range2 = sheet.get_Range(sheet.Cells[11, 4], sheet.Cells[16, 4]);
            Excel.Range range3 = sheet.get_Range(sheet.Cells[21, 4], sheet.Cells[24, 4]);
            Excel.Range range4 = sheet.get_Range(sheet.Cells[28, 4], sheet.Cells[30, 4]);
            range1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;*/
            string autocost1 = autocost.Text;
            autocost1 = autocost1 + "$";
            sheet.Cells[6, 4] = autocost1;

            string Auc1 = Auc.Text;
            Auc1 = Auc1 + "$";
            sheet.Cells[7, 4] = Auc1;

            string total1 = Total1.Text;
            total1 += "$";
            sheet.Cells[8, 4] = total1;

            string deliverLand1 = deliverLand.Text;
            deliverLand1 = deliverLand1 + "$";
            sheet.Cells[11, 4] = deliverLand1;

            string deliverSea1 = deliverSea.Text;
            deliverSea1 += "$";
            sheet.Cells[12, 4] = deliverSea1;

            string insurance2 = inshurance.Text;
            insurance2 += "$";
            sheet.Cells[13, 4] = insurance2;

            string portstay1 = portstay.Text;
            portstay1 += "$";
            sheet.Cells[14, 4] = portstay1;

            string money1 = money.Text;
            money1 += "$";
            sheet.Cells[16, 4] = money1;

            string total2 = Total2.Text;
            total2 += "$";
            sheet.Cells[17, 4] = total2;

            string portraz1 = portraz.Text;
            portraz1 += "$";
            sheet.Cells[21, 4] = portraz1;

            string tamoz1 = tamoz.Text;
            tamoz1 += "$";
            sheet.Cells[22, 4] = tamoz1;

            string StayPortOdessa = "40$";
            sheet.Cells[23, 4] = StayPortOdessa;

            string result1 = result.Text;
            result1 += "$";
            sheet.Cells[24, 4] = result1;

            string total3 = Total3.Text;
            total3 += "$";
            sheet.Cells[25, 4] = total3;

            string sertificat1 = sertificat.Text;
            sertificat1 += "$";
            sheet.Cells[28, 4] = sertificat1;

            string Pens1 = Pens.Text;
            Pens1 += "$";
            sheet.Cells[29, 4] = Pens1;

            string Mreo = "50$";
            sheet.Cells[30, 4] = Mreo;

            string total4 = Total4.Text;
            total4 += "$";
            sheet.Cells[31, 4] = total4;
        }

        private void Auc_TextChanged(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            result.Clear();
            Pens.Clear();
            aks.Clear();
            poshl.Clear();
            nds.Clear();
            Auc.Clear();
            deliverLand.Clear();
            portraz.Clear();
            tamoz.Clear();
            portstay.Clear();
            sertificat.Clear();
            money.Clear();
            autouk.Clear();
            endall.Clear();
            deliverSea.Clear();
            inshurance.Clear();
            year.Clear();
            enginee.Clear();
            autocost.Clear();
            killmepls.Clear();
            MREO.Clear();
            StayPortOdessa.Clear();
            GAS.Checked = false;
            diz.Checked = false;
            hub.Checked = false;
            ele.Checked = false;
            Copart.Checked = false;
            Iaai.Checked = false;
            manualInputAuc.Checked = false;
            insurance0.Checked = false;
            insuranse6.Checked = false;
            insuranse9.Checked = false;
        }

        private void StayPortOdessa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

