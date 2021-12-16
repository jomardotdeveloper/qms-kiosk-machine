using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskQMS.Kiosk
{
    public class TokenPrinter
    {
        private PrintDocument PrintDocument;
        private Graphics graphics;
        private string  PRINTER_NAME = "POS-58";

        private string Token;
        private string Service;
        private string Number;
        private string ID;
        private string Date;

        public TokenPrinter(string token, string service, string number, string id, string date)
        {
            this.Token = token;
            this.Service = service;
            this.Number = number;
            this.ID = id;
            this.Date = date;
        }

        public void Print()
        {
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = this.PRINTER_NAME;

            PrintDocument.PrintPage += new PrintPageEventHandler(FormatPage);
            PrintDocument.Print();
        }

        void DrawAtStart(string text, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }
        void InsertItem(string key, string value, int Offset)
        {
            Font minifont = new Font("Arial", 5);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font titleFont = new Font("Arial", 18);
            Font tokenFont = new Font("Arial", 30);
            Font serviceFont = new Font("Arial", 10);
            Font refNumberFont = new Font("Arial", 15);
            Font dateFont = new Font("Arial", 12);

            int Offset = 10;
            DrawLine(Global.BranchName, titleFont, Offset, 0);
            Offset += 40;
            DrawLine("Ticket Number", titleFont, Offset, 0);
            Offset += 40;
            DrawLine(GetToken(), tokenFont, Offset, 0);
            Offset += 60;
            DrawLine(GetService(), serviceFont, Offset, 0);
            Offset += 40;
            DrawLine(GetDate(), dateFont, Offset, 0);
            Offset += 40;
            DrawLine("                                     ", refNumberFont, Offset, 0);
            Offset += 40;
            DrawLine("                                     ", refNumberFont, Offset, 0);
            Offset += 40;
            DrawLine("                                     ", refNumberFont, Offset, 0);
            Offset += 40;
            DrawLine("                  .                   ", refNumberFont, Offset, 0);

        }

        private string GetToken()
        {
            int requiredNumberOfChar = 7;
            int numSpaces = requiredNumberOfChar - this.Token.Length;
            string str = "";

            for(int i = 0; i < numSpaces; i++)
            {
                str += " ";
            }
            return str + this.Token;
        }

        private string GetDate()
        {
            return " " + this.Date;
        }

        private string GetID()
        {
            int requiredNumberOfChar = 5;
            int numZeros = requiredNumberOfChar - this.ID.Length;
            string zeros = "";

            for(int i = 0; i < numZeros; i++)
            {
                zeros += "0";
            }

            return "    ref. no: " + zeros + this.ID;
        }

        private string GetService()
        {
            int requiredNumberOfChar = 24;
            int numSpaces = requiredNumberOfChar - this.Service.Length;
            string str = "";

            if(this.Service == "Loan Transaction / Application / Inquiry")
            {
                return "Loan Transaction/Application\n/ Inquiry";
            }
            else
            {
                for(int i = 0; i < numSpaces; i++)
                {
                    str += " ";
                }
            }

            return str + this.Service;
        }

    }
}
