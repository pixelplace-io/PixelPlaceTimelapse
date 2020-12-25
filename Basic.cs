using System;
using System.Net;


namespace MVPTimelapseRecorder
{
    class Basic
    {
        //currently unused
        public int SCNumber = 0;

        //entry point (add you own TakeImage(canvasid) here!)
        static void Main(string[] args)
        {
            bool x = true;
            while (x)
            {
                TakeImage(8);
                TakeImage(7);
                TakeImage(17721);
                Console.WriteLine("Screenshot has been taken. Total count of 8 images taken: " + Globals.SCCount);
                Console.WriteLine("Screenshot has been taken. Total count of 7 images taken: " + Globals.SCCount7);
                Console.WriteLine("Screenshot has been taken. Total count of DREW images taken: " + Globals.SCCount17721);
                Console.WriteLine("Screenshot has been taken. Total count of OTHER images taken: " + Globals.SCCountOther);
                //DELAY BETWEEN LOOPS (IN MS, ANYTHING BELOW 20 SECONDS IS UNOPTIMAL AND WILL LEAD TO DUPLICATE IMAGES!)
                System.Threading.Thread.Sleep(20000);
                
            }
        }
        //download image from pixelplace.io servers and save it 
        static void TakeImage(int canvasid)
        {
            //url for the image (don't change this unless Owmince puts the images elsewhere)
            string url = "https://pixelplace.io/canvas/" + canvasid.ToString() + ".png";
            //idk why I did it like this, completely unnecesary...
            int number = Globals.SCCount;
            int number2 = Globals.SCCount7;
            int number3 = Globals.SCCount17721;
            int number4 = Globals.SCCountOther;

            //webclient for download
            using (WebClient client = new WebClient())
            {
                //this decides the name + location of file
                switch (canvasid)
                {
                    //pre-defined cases for canvases
                    //make sure to change the path of the files to match your PC
                    case 8:
                        client.DownloadFile(new Uri(url), @"c:\SC8\" + number.ToString() + ".png");
                        Console.WriteLine("Did EDITHERE");
                        Globals.SCCount++;
                        break;
                    case 7:
                        client.DownloadFile(new Uri(url), @"c:\SC7\" + number2.ToString() + ".png");
                        Console.WriteLine("Did EDITHERE");
                        Globals.SCCount7++;
                        break;
                    case 17721:
                        client.DownloadFile(new Uri(url), @"c:\SCDrew\" + number3.ToString() + ".png");
                        Console.WriteLine("Did EDITHERE");
                        Globals.SCCount17721++;
                        break;
                    //you may add your own case here, or just use this default one
                    default:
                        client.DownloadFile(new Uri(url), @"c:\SCOther\" + number4.ToString() + ".png");
                        Console.WriteLine("Did " + canvasid);
                        Globals.SCCountOther++;
                        break;
                }
            }
        }
    }
    //counters (used for the file names)
    public static class Globals
    {
        public static int SCCount = 0;
        public static int SCCount7 = 0;
        public static int SCCount17721 = 0;
        public static int SCCountOther = 0;
    }
}
