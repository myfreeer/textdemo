using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // 引用输入输出操作的命令空间
namespace ReadWriteFile
{
    class Program
    {
        // 主函数
        //const string bpm="150";
        static void Main(string[] args)
        {
        	string x="",z="";
        	int y=0;
        	try
        	{
        		x=Convert.ToString(args[0]);
        	}
        	catch{
        	Console.WriteLine("Error:No input file.");Console.ReadKey();Environment.Exit(-1);}
        	        	try
        	{
        		y=Convert.ToInt32(args[1]);
        	}
        	catch{
Console.WriteLine("Warning:bpm not defined, using 150");y=150;}
try
        	{
        		z=Convert.ToString(args[2]);
        	}
        	catch{
Console.WriteLine("Warning:voice not defined, using New Geping UTAU Database");z="New Geping UTAU Database";}
            if (args[0]==null){Console.WriteLine("Error:No input file.");Environment.Exit(-1);}
            Read(args[0],y.ToString(),z); // 读操作
            //Write(); // 写操作
        }
        // 读操作
        public static void Read(string s,string bpm,string voice)
        {
            if (s==null){Console.WriteLine("Error:No input file.");Environment.Exit(-1);}
            // 读取文件的源路径及其读取流
            string strReadFilePath = @s;
            StreamReader srReadFile=new StreamReader((System.IO.Stream)File.OpenRead(strReadFilePath),System.Text.Encoding.GetEncoding("gb2312"));
            // 读取流直至文件末尾结束
            while (!srReadFile.EndOfStream)
            {
                string strReadLine = srReadFile.ReadLine(); //读取每行数据
                //int filelength = strReadLine.Length%256>0?strReadLine.Length/256+1:strReadLine.Length/256;
                int filelength = strReadLine.Length/256;
                //Console.WriteLine(filelength); 
                //Console.WriteLine(filelength*256); 
                //Console.WriteLine(strReadLine.Length); 
                for (int i=0;i<filelength;i++){
                	Console.Write("Writing File ");
                	Console.Write(i+1);
                	Console.Write(" of ");
                	Console.Write(filelength);
                	Console.WriteLine(" ..."); 
                	string name="numbers_"+i.ToString();
                	string header="[#SETTING]\r\nUstVersion=1.19\r\nTempo="+bpm+"\r\nTracks=1\r\nProjectName="+name+"\r\nVoiceDir=%VOICE%"+voice+"\r\nOutFile="+name+".wav\r\nCacheDir="+name+".cache\r\nTool1=wavtool.exe\r\nTool2=resampler.exe\r\nMode2=True\r\n";
                	string fname=name+".ust";
                	string ender="[#TRACKEND]";
                	Write(header,fname);
                	//Console.WriteLine(strReadLine.Substring(i*256,256));
                	Count(strReadLine.Substring(i*256,256),i);
                	//Console.WriteLine(i);
                	//Console.WriteLine(i*256); 
                	Write(ender,fname);
                	Write(strReadLine.Substring(i*256,256),name+"_data.txt");
                }
            //Console.WriteLine(strReadLine); //屏幕打印每行数据

            }
            // 关闭读取流文件
            srReadFile.Close();
            Console.WriteLine("Done!\nPress Any Key To Exit."); 
            Console.ReadKey();
        }
        public static void Count(string str,int times)
        {
        	if (str.Length!=256) return;
        	for (int i=0;i<256;i++){
        		/*
        		Console.Write("ptimes=");
        		Console.Write(i+1);
        		Console.Write("；times=");
        		Console.Write(times*256+i+1);
        		Console.Write("；data=");
        		Console.Write(str.Substring(i,1));
        		Console.Write("\r\n");
        		*/
        		Convt1(str.Substring(i,1),times,i);
        	}
        }
        public static void Convt1(string str,int times,int ptimes)
        {
        	switch (str)
        	{
         	   case "1":
          	      //Console.WriteLine("Case 1");
          	      Convt2("yi",times,ptimes);
          	      break;
          	  case "2":
               	 //Console.WriteLine("Case 2");
          	      Convt2("er",times,ptimes);
           	     break;
          	  case "3":
          	      //Console.WriteLine("Case 3");
          	      Convt2("san",times,ptimes);
          	      break;
          	  case "4":
          	      //Console.WriteLine("Case 4");
          	      Convt2("si",times,ptimes);
           	     break;
          	  case "5":
           	     //Console.WriteLine("Case 5");
          	      Convt2("wu",times,ptimes);
           	     break;
          	  case "6":
          	      //Console.WriteLine("Case 6");
          	      Convt2("liu",times,ptimes);
           	     break;
           	 case "7":
           	     //Console.WriteLine("Case 7");
          	      Convt2("qi",times,ptimes);
           	     break;
        	   case "8":
           	     //Console.WriteLine("Case 8");
          	      Convt2("ba",times,ptimes);
           	     break;
          	  case "9":
           	    // Console.WriteLine("Case 9");
          	      Convt2("jiu",times,ptimes);
           	     break;
         	   case "0":
           	    // Console.WriteLine("Case 0");
          	      Convt2("ling",times,ptimes);
         	       break;
         	   case ".":
         	      // Console.WriteLine("Case .");
          	      Convt2("dian",times,ptimes);
        	        break;
          	  default:
         	       Console.WriteLine("ERROR: Only Numbers and \".\" are allowed.");
         	       Console.WriteLine(times);
         	       Console.WriteLine(ptimes);
         	       Console.WriteLine(str);
         	  Console.ReadKey();
         	       break;
        	}
        }
        public static void Convt2(string py,int times,int ptimes)
        {
        	string name="numbers_"+times.ToString();
        	string fname=name+".ust";
        	string data="";
        	switch (ptimes)
        	{
        		case 0:
data="[#0000]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,37.7,0,100,100,0\r\n";
break;
case 1:
data="[#0001]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 2:
data="[#0002]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,67.2,0,100,100,0\r\n";
break;
case 3:
data="[#0003]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 4:
data="[#0004]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,16.9,35,0,100,100,0\r\n";
break;
case 5:
data="[#0005]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 6:
data="[#0006]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 7:
data="[#0007]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,52.3,0,100,100,0\r\n";
break;
case 8:
data="[#0008]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 9:
data="[#0009]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 10:
data="[#0010]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 11:
data="[#0011]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 12:
data="[#0012]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 13:
data="[#0013]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 14:
data="[#0014]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 15:
data="[#0015]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 16:
data="[#0016]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 17:
data="[#0017]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 18:
data="[#0018]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 19:
data="[#0019]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 20:
data="[#0020]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 21:
data="[#0021]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 22:
data="[#0022]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,52.3,0,100,100,0\r\n";
break;
case 23:
data="[#0023]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 24:
data="[#0024]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 25:
data="[#0025]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 26:
data="[#0026]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\n";
break;
case 27:
data="[#0027]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 28:
data="[#0028]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 29:
data="[#0029]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 30:
data="[#0030]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 31:
data="[#0031]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 32:
data="[#0032]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,55,0,100,100,0\r\n";
break;
case 33:
data="[#0033]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 34:
data="[#0034]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 35:
data="[#0035]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 36:
data="[#0036]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 37:
data="[#0037]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 38:
data="[#0038]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,16.9,35,0,100,100,0\r\n";
break;
case 39:
data="[#0039]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 40:
data="[#0040]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 41:
data="[#0041]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\n";
break;
case 42:
data="[#0042]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 43:
data="[#0043]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 44:
data="[#0044]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 45:
data="[#0045]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 46:
data="[#0046]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 47:
data="[#0047]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 48:
data="[#0048]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 49:
data="[#0049]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 50:
data="[#0050]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,55,0,100,100,0\r\n";
break;
case 51:
data="[#0051]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 52:
data="[#0052]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 53:
data="[#0053]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 54:
data="[#0054]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,55,0,100,100,0\r\n";
break;
case 55:
data="[#0055]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 56:
data="[#0056]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 57:
data="[#0057]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 58:
data="[#0058]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 59:
data="[#0059]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 60:
data="[#0060]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 61:
data="[#0061]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 62:
data="[#0062]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 63:
data="[#0063]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 64:
data="[#0064]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 65:
data="[#0065]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 66:
data="[#0066]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 67:
data="[#0067]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 68:
data="[#0068]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 69:
data="[#0069]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\n";
break;
case 70:
data="[#0070]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 71:
data="[#0071]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 72:
data="[#0072]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\n";
break;
case 73:
data="[#0073]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 74:
data="[#0074]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 75:
data="[#0075]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,52.3,0,100,100,0\r\n";
break;
case 76:
data="[#0076]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 77:
data="[#0077]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,55,0,100,100,0\r\n";
break;
case 78:
data="[#0078]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 79:
data="[#0079]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 80:
data="[#0080]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 81:
data="[#0081]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 82:
data="[#0082]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,52.3,0,100,100,0\r\n";
break;
case 83:
data="[#0083]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 84:
data="[#0084]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 85:
data="[#0085]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,55,0,100,100,0\r\n";
break;
case 86:
data="[#0086]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 87:
data="[#0087]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\n";
break;
case 88:
data="[#0088]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 89:
data="[#0089]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 90:
data="[#0090]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 91:
data="[#0091]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 92:
data="[#0092]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 93:
data="[#0093]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 94:
data="[#0094]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 95:
data="[#0095]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 96:
data="[#0096]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 97:
data="[#0097]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 98:
data="[#0098]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 99:
data="[#0099]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 100:
data="[#0100]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 101:
data="[#0101]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 102:
data="[#0102]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 103:
data="[#0103]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 104:
data="[#0104]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,67.2,0,100,100,0\r\n";
break;
case 105:
data="[#0105]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 106:
data="[#0106]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,55,0,100,100,0\r\n";
break;
case 107:
data="[#0107]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 108:
data="[#0108]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,52.3,0,100,100,0\r\n";
break;
case 109:
data="[#0109]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 110:
data="[#0110]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 111:
data="[#0111]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 112:
data="[#0112]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 113:
data="[#0113]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 114:
data="[#0114]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 115:
data="[#0115]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 116:
data="[#0116]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 117:
data="[#0117]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 118:
data="[#0118]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 119:
data="[#0119]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 120:
data="[#0120]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 121:
data="[#0121]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 122:
data="[#0122]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 123:
data="[#0123]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 124:
data="[#0124]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 125:
data="[#0125]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 126:
data="[#0126]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 127:
data="[#0127]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 128:
data="[#0128]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 129:
data="[#0129]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\n";
break;
case 130:
data="[#0130]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 131:
data="[#0131]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 132:
data="[#0132]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,55,0,100,100,0\r\n";
break;
case 133:
data="[#0133]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 134:
data="[#0134]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 135:
data="[#0135]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 136:
data="[#0136]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 137:
data="[#0137]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 138:
data="[#0138]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 139:
data="[#0139]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 140:
data="[#0140]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 141:
data="[#0141]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 142:
data="[#0142]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 143:
data="[#0143]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 144:
data="[#0144]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 145:
data="[#0145]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 146:
data="[#0146]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 147:
data="[#0147]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\n";
break;
case 148:
data="[#0148]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 149:
data="[#0149]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 150:
data="[#0150]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 151:
data="[#0151]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 152:
data="[#0152]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 153:
data="[#0153]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 154:
data="[#0154]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 155:
data="[#0155]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 156:
data="[#0156]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 157:
data="[#0157]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 158:
data="[#0158]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 159:
data="[#0159]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,55,0,100,100,0\r\n";
break;
case 160:
data="[#0160]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 161:
data="[#0161]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 162:
data="[#0162]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 163:
data="[#0163]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 164:
data="[#0164]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,16.9,55,0,100,100,0\r\n";
break;
case 165:
data="[#0165]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 166:
data="[#0166]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 167:
data="[#0167]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 168:
data="[#0168]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 169:
data="[#0169]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 170:
data="[#0170]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 171:
data="[#0171]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 172:
data="[#0172]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 173:
data="[#0173]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 174:
data="[#0174]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 175:
data="[#0175]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 176:
data="[#0176]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,55,0,100,100,0\r\n";
break;
case 177:
data="[#0177]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 178:
data="[#0178]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 179:
data="[#0179]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 180:
data="[#0180]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 181:
data="[#0181]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 182:
data="[#0182]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 183:
data="[#0183]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 184:
data="[#0184]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 185:
data="[#0185]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 186:
data="[#0186]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 187:
data="[#0187]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 188:
data="[#0188]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 189:
data="[#0189]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 190:
data="[#0190]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 191:
data="[#0191]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 192:
data="[#0192]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,67.2,0,100,100,0\r\n";
break;
case 193:
data="[#0193]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 194:
data="[#0194]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 195:
data="[#0195]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 196:
data="[#0196]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 197:
data="[#0197]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\n";
break;
case 198:
data="[#0198]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 199:
data="[#0199]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 200:
data="[#0200]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 201:
data="[#0201]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 202:
data="[#0202]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 203:
data="[#0203]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 204:
data="[#0204]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 205:
data="[#0205]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 206:
data="[#0206]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 207:
data="[#0207]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,55,0,100,100,0\r\n";
break;
case 208:
data="[#0208]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 209:
data="[#0209]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 210:
data="[#0210]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 211:
data="[#0211]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,52.3,0,100,100,0\r\n";
break;
case 212:
data="[#0212]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 213:
data="[#0213]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 214:
data="[#0214]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 215:
data="[#0215]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 216:
data="[#0216]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\n";
break;
case 217:
data="[#0217]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\n";
break;
case 218:
data="[#0218]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 219:
data="[#0219]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 220:
data="[#0220]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\n";
break;
case 221:
data="[#0221]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,16.9,35,0,100,100,0\r\n";
break;
case 222:
data="[#0222]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 223:
data="[#0223]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\n";
break;
case 224:
data="[#0224]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 225:
data="[#0225]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 226:
data="[#0226]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,52.3,0,100,100,0\r\n";
break;
case 227:
data="[#0227]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 228:
data="[#0228]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
case 229:
data="[#0229]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 230:
data="[#0230]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 231:
data="[#0231]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 232:
data="[#0232]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\n";
break;
case 233:
data="[#0233]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 234:
data="[#0234]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,52.3,0,100,100,0\r\n";
break;
case 235:
data="[#0235]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 236:
data="[#0236]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 237:
data="[#0237]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\n";
break;
case 238:
data="[#0238]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\n";
break;
case 239:
data="[#0239]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\n";
break;
case 240:
data="[#0240]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 241:
data="[#0241]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\n";
break;
case 242:
data="[#0242]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\n";
break;
case 243:
data="[#0243]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\n";
break;
case 244:
data="[#0244]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 245:
data="[#0245]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,55,0,100,100,0\r\n";
break;
case 246:
data="[#0246]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\n";
break;
case 247:
data="[#0247]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,35,0,100,100,0\r\n";
break;
case 248:
data="[#0248]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 249:
data="[#0249]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\n";
break;
case 250:
data="[#0250]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\n";
break;
case 251:
data="[#0251]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,16.9,67.2,0,100,100,0\r\n";
break;
case 252:
data="[#0252]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\n";
break;
case 253:
data="[#0253]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,52.3,0,100,100,0\r\n";
break;
case 254:
data="[#0254]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\n";
break;
case 255:
data="[#0255]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,51.3,95,0,100,100,0\r\n";
break;
          	  default:
         	       Console.WriteLine("ERROR: Function Convt2 is broken.");
         	       Console.WriteLine(py);
         	       Console.WriteLine(ptimes);
         	       Console.WriteLine(times);
         	  Console.ReadKey();
         	       break;
        	}
        	Write(data,fname);
        }
        // 写操作
        public static void Write(string data,string file)
        {
        	try{
        	using (System.IO.StreamWriter filew = 
            new System.IO.StreamWriter(@file, true))
        {
            filew.WriteLine(data);
        }
    }
    catch{
    	Console.WriteLine("ERROR:Cannot write file" + file);
    }
            // 统计写入（读取的行数）
            //int WriteRows = 0;
            // 读取文件的源路径及其读取流
            //string strReadFilePath = @"../../data/ReadLog.txt";
            //StreamReader srReadFile = new StreamReader(strReadFilePath);
            // 写入文件的源路径及其写入流
            //string strWriteFilePath = @file;
           // StreamWriter swWriteFile = File.CreateText(strWriteFilePath);
            // 读取流直至文件末尾结束，并逐行写入另一文件内
            //while (!srReadFile.EndOfStream)
            //{
                //string strReadLine = srReadFile.ReadLine(); //读取每行数据
                //++WriteRows; //统计写入（读取）的数据行数
              //  swWriteFile.WriteLine(data); //写入读取的每行数据
                //Console.WriteLine("正在写入... " + strReadLine);
            //}
            // 关闭流文件
            //srReadFile.Close();
            //swWriteFile.Close();
            //Console.WriteLine("共计写入记录总数：" + WriteRows);
            //Console.ReadKey();
        }
    }
}
