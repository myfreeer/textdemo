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
data="[#0000]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,7,7,6,5,3,1,0,-2,-2,-3,-3,-3,-2,-1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,7,7,6,5,3,1,0,-2,-2,-3,-3,-3,-2,-1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,7,7,6,5,3,1,0,-2,-2,-3,-3,-3,-2,-1,0\r\nEnvelope=0,5,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,70.5547537068653,0,0\r\nPBStart=-144.583\r\n";
break;
case 1:
data="[#0001]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 2:
data="[#0002]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,67.2,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 3:
data="[#0003]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 4:
data="[#0004]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,9,8,7,5,3,2,1,0,0,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,9,8,7,5,3,2,1,0,0,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,9,8,7,5,3,2,1,0,0,0,0,0,0\r\nEnvelope=0,16.9,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,30.1948016245043,0,0\r\nPBStart=-56.738\r\n";
break;
case 5:
data="[#0005]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 6:
data="[#0006]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-4,-4,-4,-4,-3,-2,-1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-4,-4,-4,-4,-3,-2,-1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-4,-4,-4,-4,-3,-2,-1,0,0,0,0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,1.40176411080962,0,0\r\nPBStart=-64\r\n";
break;
case 7:
data="[#0007]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-5,-6,-8,-10,-9,-7,-6,-4,-3,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-5,-6,-8,-10,-9,-7,-6,-4,-3,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-5,-6,-8,-10,-9,-7,-6,-4,-3,-2,-1,0,0\r\nEnvelope=0,10,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,76.0723626567794,0,0\r\nPBStart=-27\r\n";
break;
case 8:
data="[#0008]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 9:
data="[#0009]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,70.9037915516511,0,0\r\nPBStart=-24\r\n";
break;
case 10:
data="[#0010]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 11:
data="[#0011]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-1,5,15,29,46,65,87,107,127,146,163,176,187\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-1,5,15,29,46,65,87,107,127,146,163,176,187\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-1,5,15,29,46,65,87,107,127,146,163,176,187\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,41.4032710671795,0,0\r\nPBStart=-24\r\n";
break;
case 12:
data="[#0012]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-12,-23,-38,-57,-76,-98,-120,-140,-158,-174,-186,-195,-199,-200,-200\r\nPitches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-12,-23,-38,-57,-76,-98,-120,-140,-158,-174,-186,-195,-199,-200,-200\r\nPitchBend=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-12,-23,-38,-57,-76,-98,-120,-140,-158,-174,-186,-195,-199,-200,-200\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,86.2619348354685,0,0\r\nPBStart=-8.42\r\n";
break;
case 13:
data="[#0013]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,64,82,99,118,135,153,168,180,191,197,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,64,82,99,118,135,153,168,180,191,197,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,64,82,99,118,135,153,168,180,191,197,200,200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,79.0480028705872,0,0\r\nPBStart=0\r\n";
break;
case 14:
data="[#0014]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,0,1,2,1,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,0,1,2,1,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,0,1,2,1,1,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,37.3536177573331,0,0\r\nPBStart=0\r\n";
break;
case 15:
data="[#0015]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-23,-37,-54,-72,-90,-112,-133,-153,-169,-183,-193,-198,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-23,-37,-54,-72,-90,-112,-133,-153,-169,-183,-193,-198,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-23,-37,-54,-72,-90,-112,-133,-153,-169,-183,-193,-198,-200,-200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,96.1953142074894,0,0\r\nPBStart=0\r\n";
break;
case 16:
data="[#0016]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0\r\nPitches=0\r\nPitchBend=0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 17:
data="[#0017]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,3,1,-1,-2,-2,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,3,1,-1,-2,-2,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,3,1,-1,-2,-2,-2,-1,0,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,5.62368653091138,0,0\r\nPBStart=-27\r\n";
break;
case 18:
data="[#0018]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 19:
data="[#0019]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 20:
data="[#0020]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,-1,0,0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,52.486842911782,0,0\r\nPBStart=-100\r\n";
break;
case 21:
data="[#0021]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 22:
data="[#0022]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,2,1,-1,-2,-2,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,2,1,-1,-2,-2,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,6,5,2,1,-1,-2,-2,-2,-1,0,0\r\nEnvelope=0,10,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,5.35045287658279,0,0\r\nPBStart=-27\r\n";
break;
case 23:
data="[#0023]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 24:
data="[#0024]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,3,2,1,-1,-3,-4,-5,-5,-5,-4,-3,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,3,2,1,-1,-3,-4,-5,-5,-5,-4,-3,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,3,2,1,-1,-3,-4,-5,-5,-5,-4,-3,-2,-1,0,0\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,46.8700102859752,0,0\r\nPBStart=-100\r\n";
break;
case 25:
data="[#0025]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-4,-4,-3,-1,1,2,3,3,3,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-4,-4,-3,-1,1,2,3,3,3,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-4,-4,-3,-1,1,2,3,3,3,2,1,0,0\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,29.8165438509942,0,0\r\nPBStart=0\r\n";
break;
case 26:
data="[#0026]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 27:
data="[#0027]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-17,-28,-39,-51,-61,-70,-79,-86,-93,-97,-100,-100,-100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-17,-28,-39,-51,-61,-70,-79,-86,-93,-97,-100,-100,-100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-17,-28,-39,-51,-61,-70,-79,-86,-93,-97,-100,-100,-100\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,64.782120671541,0,0\r\nPBStart=-8.42\r\n";
break;
case 28:
data="[#0028]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 29:
data="[#0029]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,24,40,58,79,99,119,136,154,169,181,191,197,200,200\r\nPitches=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,24,40,58,79,99,119,136,154,169,181,191,197,200,200\r\nPitchBend=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,24,40,58,79,99,119,136,154,169,181,191,197,200,200\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,27.9342063258061,0,0\r\nPBStart=-27\r\n";
break;
case 30:
data="[#0030]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,82.9801655430608,0,0\r\nPBStart=0\r\n";
break;
case 31:
data="[#0031]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 32:
data="[#0032]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-6,-4,-2,-1,0,1,1,1,0,0\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-6,-4,-2,-1,0,1,1,1,0,0\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-6,-4,-2,-1,0,1,1,1,0,0\r\nEnvelope=0,12,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,58.9163010886405,0,0\r\nPBStart=-24\r\n";
break;
case 33:
data="[#0033]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 34:
data="[#0034]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-4,-3,-2,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,91.0964337991924,0,0\r\nPBStart=-27\r\n";
break;
case 35:
data="[#0035]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-2,0,1,3,5,5,5,4,4,2,1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-2,0,1,3,5,5,5,4,4,2,1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-2,0,1,3,5,5,5,4,4,2,1,0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,22.6866004456069,0,0\r\nPBStart=-8.42\r\n";
break;
case 36:
data="[#0036]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 37:
data="[#0037]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 38:
data="[#0038]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nEnvelope=0,16.9,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,24.3931345933832,0,0\r\nPBStart=-56.738\r\n";
break;
case 39:
data="[#0039]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-10,-9,-7,-5,-3,-2,-1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-10,-9,-7,-5,-3,-2,-1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-10,-9,-7,-5,-3,-2,-1,0,0,0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,53.3873084901097,0,0\r\nPBStart=0\r\n";
break;
case 40:
data="[#0040]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 41:
data="[#0041]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,-1,-3,-5,-6,-8,-9,-8,-7,-6,-4,-3,-2,-1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,-1,-3,-5,-6,-8,-9,-8,-7,-6,-4,-3,-2,-1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,-1,-3,-5,-6,-8,-9,-8,-7,-6,-4,-3,-2,-1,0,0,0\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,99.9414528833681,0,0\r\nPBStart=-56.738\r\n";
break;
case 42:
data="[#0042]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,-2,-4,-6,-7,-7,-6,-5,-4,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,-2,-4,-6,-7,-7,-6,-5,-4,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,-2,-4,-6,-7,-7,-6,-5,-4,-2,-1,0,0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,67.6175902253819,0,0\r\nPBStart=0\r\n";
break;
case 43:
data="[#0043]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,8,18,32,48,68,89,109,127,145,161,174,185,194,198,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,8,18,32,48,68,89,109,127,145,161,174,185,194,198,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,8,18,32,48,68,89,109,127,145,161,174,185,194,198,200,200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,1.57039163930437,0,0\r\nPBStart=0\r\n";
break;
case 44:
data="[#0044]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-17,-30,-47,-67,-88,-109,-128,-145,-162,-175,-186,-194,-198,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-17,-30,-47,-67,-88,-109,-128,-145,-162,-175,-186,-194,-198,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-17,-30,-47,-67,-88,-109,-128,-145,-162,-175,-186,-194,-198,-200,-200\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,57.5183814494122,0,0\r\nPBStart=0\r\n";
break;
case 45:
data="[#0045]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,46,66,87,108,128,146,162,176,186,195,199,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,46,66,87,108,128,146,162,176,186,195,199,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,46,66,87,108,128,146,162,176,186,195,199,200,200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,10.0052234757156,0,0\r\nPBStart=0\r\n";
break;
case 46:
data="[#0046]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,9,7,6,5,3,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,9,7,6,5,3,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,9,7,6,5,3,2,1,0,0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,10.3022636595326,0,0\r\nPBStart=0\r\n";
break;
case 47:
data="[#0047]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-24,-39,-57,-77,-98,-120,-140,-159,-174,-186,-195,-199,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-24,-39,-57,-77,-98,-120,-140,-159,-174,-186,-195,-199,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-5,-13,-24,-39,-57,-77,-98,-120,-140,-159,-174,-186,-195,-199,-200,-200\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,79.8884424697591,0,0\r\nPBStart=0\r\n";
break;
case 48:
data="[#0048]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0\r\nPitches=0\r\nPitchBend=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 49:
data="[#0049]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 50:
data="[#0050]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,7,7,5,3,1,0,-1,-2,-2,-1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,7,7,5,3,1,0,-1,-2,-2,-1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,7,7,5,3,1,0,-1,-2,-2,-1,0,0,0\r\nEnvelope=0,22.9,55,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,29.5772842216434,0,0\r\nPBStart=-56.738\r\n";
break;
case 51:
data="[#0051]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 52:
data="[#0052]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,1,2,4,6,6,6,6,4,3,2,1\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,1,2,4,6,6,6,6,4,3,2,1\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,1,2,4,6,6,6,6,4,3,2,1\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,30.0970502338328,0,0\r\nPBStart=-24\r\n";
break;
case 53:
data="[#0053]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 54:
data="[#0054]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-3,-4,-3,-3,-2,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-3,-4,-3,-3,-2,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,4,3,2,0,-2,-3,-3,-4,-3,-3,-2,0,0\r\nEnvelope=0,10,55,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,97.9829340843624,0,0\r\nPBStart=-27\r\n";
break;
case 55:
data="[#0055]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-7,-4,-2,-1,0,1,1,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-7,-4,-2,-1,0,1,1,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-7,-4,-2,-1,0,1,1,1,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,40.1374359028506,0,0\r\nPBStart=0\r\n";
break;
case 56:
data="[#0056]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,-3,-3,-1,0,2,3,4,4,3,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,-3,-3,-1,0,2,3,4,4,3,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,-3,-3,-1,0,2,3,4,4,3,2,1,0,0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,27.8279968842124,0,0\r\nPBStart=0\r\n";
break;
case 57:
data="[#0057]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 58:
data="[#0058]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-8,-5,-4,-2,0,1,1,1,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-8,-5,-4,-2,0,1,1,1,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-7,-8,-8,-8,-5,-4,-2,0,1,1,1,1,0,0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,16.2821597338582,0,0\r\nPBStart=-100\r\n";
break;
case 59:
data="[#0059]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 60:
data="[#0060]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-500,-500,-500,-500,-500,-496,-486,-470,-449,-423,-393,-359,-323,-285,-246,-207,-170,-134,-101,-71,-46,-26,-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nPitches=-500,-500,-500,-500,-500,-496,-486,-470,-449,-423,-393,-359,-323,-285,-246,-207,-170,-134,-101,-71,-46,-26,-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nPitchBend=-500,-500,-500,-500,-500,-496,-486,-470,-449,-423,-393,-359,-323,-285,-246,-207,-170,-134,-101,-71,-46,-26,-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 61:
data="[#0061]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,4,3,-4,-17,-34,-58,-87,-118,-150,-183,-217,-250,-281,-309,-336,-359,-377,-390\r\nPitches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,4,3,-4,-17,-34,-58,-87,-118,-150,-183,-217,-250,-281,-309,-336,-359,-377,-390\r\nPitchBend=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,4,3,-4,-17,-34,-58,-87,-118,-150,-183,-217,-250,-281,-309,-336,-359,-377,-390\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,41.2766811000124,0,0\r\nPBStart=-100\r\n";
break;
case 62:
data="[#0062]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=86,60,38,21,9,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nPitches=86,60,38,21,9,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nPitchBend=86,60,38,21,9,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-6,-8,-10,-9,-8,-6,-4,-3,-1,-1,0,0,0\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=33,130,10,50,50,71.2730467563801,0,0\r\nPBStart=-24\r\n";
break;
case 63:
data="[#0063]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 64:
data="[#0064]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-5,-7,-8,-8,-8,-6,-4,-2,-1,0,1,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-5,-7,-8,-8,-8,-6,-4,-2,-1,0,1,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-5,-7,-8,-8,-8,-6,-4,-2,-1,0,1,1,0,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,63.3178874845709,0,0\r\nPBStart=-27\r\n";
break;
case 65:
data="[#0065]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,1,2,5,6,6,6,5,4,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,1,2,5,6,6,6,5,4,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,1,2,5,6,6,6,5,4,2,1,0,0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,20.7561138813197,0,0\r\nPBStart=0\r\n";
break;
case 66:
data="[#0066]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,0,2,3,6,6,6,6,5,4,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,0,2,3,6,6,6,6,5,4,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,-1,0,2,3,6,6,6,6,5,4,2,1,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,18.6013523638108,0,0\r\nPBStart=0\r\n";
break;
case 67:
data="[#0067]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 68:
data="[#0068]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 69:
data="[#0069]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,9,9,8,7,5,4,2,1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,9,9,8,7,5,4,2,1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,9,9,8,7,5,4,2,1,0,0,0,0\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,45.7971469384469,0,0\r\nPBStart=-56.738\r\n";
break;
case 70:
data="[#0070]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 71:
data="[#0071]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-8,-9,-10,-8,-7,-5,-3,-2,-1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-8,-9,-10,-8,-7,-5,-3,-2,-1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-8,-9,-10,-8,-7,-5,-3,-2,-1,0,0,0,0\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,26.1368268675191,0,0\r\nPBStart=-100\r\n";
break;
case 72:
data="[#0072]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-3,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-3,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,3,2,0,-2,-3,-4,-4,-3,-2,-1,0,0\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,78.5212207363004,0,0\r\nPBStart=0\r\n";
break;
case 73:
data="[#0073]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 74:
data="[#0074]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,3,5,7,7,7,6,5,4,3,1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,3,5,7,7,7,6,5,4,3,1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,3,5,7,7,7,6,5,4,3,1,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,28.9665040414889,0,0\r\nPBStart=-27\r\n";
break;
case 75:
data="[#0075]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,11,21,34,49,67,85,103,121,138,154,169,181,191,197,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,11,21,34,49,67,85,103,121,138,154,169,181,191,197,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,11,21,34,49,67,85,103,121,138,154,169,181,191,197,200,200\r\nEnvelope=0,5,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,91.9377081992629,0,0\r\nPBStart=-8.42\r\n";
break;
case 76:
data="[#0076]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 77:
data="[#0077]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,7,17,29,44,63,82,104,125,146,163,178,190,197,200,200\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,7,17,29,44,63,82,104,125,146,163,178,190,197,200,200\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,7,17,29,44,63,82,104,125,146,163,178,190,197,200,200\r\nEnvelope=0,10,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,62.7642019940534,0,0\r\nPBStart=-27\r\n";
break;
case 78:
data="[#0078]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0\r\nPitches=0\r\nPitchBend=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 79:
data="[#0079]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-13,-24,-37,-53,-70,-90,-111,-131,-150,-168,-181,-192,-198,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-13,-24,-37,-53,-70,-90,-111,-131,-150,-168,-181,-192,-198,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-13,-24,-37,-53,-70,-90,-111,-131,-150,-168,-181,-192,-198,-200,-200\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,9.7973827165469,0,0\r\nPBStart=-8.42\r\n";
break;
case 80:
data="[#0080]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-6,-8,-10,-9,-7,-6,-4,-2,-1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-6,-8,-10,-9,-7,-6,-4,-2,-1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-6,-8,-10,-9,-7,-6,-4,-2,-1,0,0,0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,56.1040086433832,0,0\r\nPBStart=0\r\n";
break;
case 81:
data="[#0081]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 82:
data="[#0082]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,6,6,5,4,2,0,-1,-2,-2,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,6,6,5,4,2,0,-1,-2,-2,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,6,6,5,4,2,0,-1,-2,-2,-2,-1,0,0\r\nEnvelope=0,5,52.3,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,91.3717587246356,0,0\r\nPBStart=-8.42\r\n";
break;
case 83:
data="[#0083]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 84:
data="[#0084]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,6,4,2,1,-1,-1,-1,-1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,6,4,2,1,-1,-1,-1,-1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,6,4,2,1,-1,-1,-1,-1,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,2.26292017176881,0,0\r\nPBStart=-27\r\n";
break;
case 85:
data="[#0085]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nEnvelope=0,5,55,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,54.3360597113198,0,0\r\nPBStart=-8.42\r\n";
break;
case 86:
data="[#0086]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,7,5,3,1,0,-1,-1,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,7,5,3,1,0,-1,-1,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,6,7,7,7,5,3,1,0,-1,-1,-1,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,91.6164009225073,0,0\r\nPBStart=0\r\n";
break;
case 87:
data="[#0087]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 88:
data="[#0088]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,8,9,10,8,6,5,3,2,1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,8,9,10,8,6,5,3,2,1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,8,9,10,8,6,5,3,2,1,0,0,0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,67.7947729215511,0,0\r\nPBStart=-100\r\n";
break;
case 89:
data="[#0089]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 90:
data="[#0090]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 91:
data="[#0091]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-19,-27,-35,-44,-53,-63,-72,-82,-89,-95,-98,-100,-100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-19,-27,-35,-44,-53,-63,-72,-82,-89,-95,-98,-100,-100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-19,-27,-35,-44,-53,-63,-72,-82,-89,-95,-98,-100,-100\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,46.2980047102839,0,0\r\nPBStart=-24\r\n";
break;
case 92:
data="[#0092]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 93:
data="[#0093]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,5,6,5,6,9,17,28,42,59,78,99,120,139,156,171,184\r\nPitches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,5,6,5,6,9,17,28,42,59,78,99,120,139,156,171,184\r\nPitchBend=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,5,6,5,6,9,17,28,42,59,78,99,120,139,156,171,184\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,40.483415340708,0,0\r\nPBStart=-100\r\n";
break;
case 94:
data="[#0094]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-72,-53,-37,-23,-12,-4,0\r\nPitches=-72,-53,-37,-23,-12,-4,0\r\nPitchBend=-72,-53,-37,-23,-12,-4,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-27\r\n";
break;
case 95:
data="[#0095]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-56.738\r\n";
break;
case 96:
data="[#0096]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=190,180,167,151,133,114,94,74,56,39,24,13,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nPitches=190,180,167,151,133,114,94,74,56,39,24,13,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nPitchBend=190,180,167,151,133,114,94,74,56,39,24,13,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,5,6,6,5,4,2,1,-1,-2,-2,-3,-2,-1,-1,0,0\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,24.3845171713803,0,0\r\nPBStart=-56.738\r\n";
break;
case 97:
data="[#0097]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,7,9,9,7,6,4,2,1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,7,9,9,7,6,4,2,1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,6,7,9,9,7,6,4,2,1,0,0,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,97.9077944143932,0,0\r\nPBStart=0\r\n";
break;
case 98:
data="[#0098]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,10,9,7,6,4,2,1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,10,9,7,6,4,2,1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,6,8,10,9,7,6,4,2,1,0,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,6.09162468822372,0,0\r\nPBStart=0\r\n";
break;
case 99:
data="[#0099]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-6,-4,-2,0,1,1,1,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-6,-4,-2,0,1,1,1,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-7,-7,-6,-4,-2,0,1,1,1,1,0,0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,39.0291466408271,0,0\r\nPBStart=0\r\n";
break;
case 100:
data="[#0100]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,1,1,2,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,1,1,2,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-6,-6,-6,-5,-3,-1,1,1,2,2,1,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,36.4995405471184,0,0\r\nPBStart=0\r\n";
break;
case 101:
data="[#0101]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 102:
data="[#0102]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 103:
data="[#0103]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 104:
data="[#0104]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,22.9,67.2,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 105:
data="[#0105]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,8,8,9,7,5,3,1,0,0,-1,-1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,8,8,9,7,5,3,1,0,0,-1,-1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,8,8,9,7,5,3,1,0,0,-1,-1,0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,62.8751887735165,0,0\r\nPBStart=-100\r\n";
break;
case 106:
data="[#0106]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-9,-9,-7,-5,-3,-2,-1,0,0,0,0\r\nEnvelope=0,5,55,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,54.2070222597001,0,0\r\nPBStart=-8.42\r\n";
break;
case 107:
data="[#0107]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 108:
data="[#0108]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-11,-22,-36,-54,-72,-94,-116,-137,-155,-172,-184,-194,-199,-200,-200\r\nPitches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-11,-22,-36,-54,-72,-94,-116,-137,-155,-172,-184,-194,-199,-200,-200\r\nPitchBend=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-4,-11,-22,-36,-54,-72,-94,-116,-137,-155,-172,-184,-194,-199,-200,-200\r\nEnvelope=0,5,52.3,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,93.8545173097371,0,0\r\nPBStart=-8.42\r\n";
break;
case 109:
data="[#0109]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 110:
data="[#0110]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0\r\nPitches=-58,-41,-27,-15,-6,-1,0\r\nPitchBend=-58,-41,-27,-15,-6,-1,0\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 111:
data="[#0111]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,-6,-15,-27,-41,-59,-80,-100,-122,-142,-160,-175,-188,-195,-199,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,-6,-15,-27,-41,-59,-80,-100,-122,-142,-160,-175,-188,-195,-199,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,-6,-15,-27,-41,-59,-80,-100,-122,-142,-160,-175,-188,-195,-199,-200,-200\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,39.0471441892901,0,0\r\nPBStart=-56.738\r\n";
break;
case 112:
data="[#0112]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0\r\nPitches=0\r\nPitchBend=0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 113:
data="[#0113]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,-1,-3,-5,-7,-8,-7,-7,-5,-4,-3,-1,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,-1,-3,-5,-7,-8,-7,-7,-5,-4,-3,-1,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,-1,-3,-5,-7,-8,-7,-7,-5,-4,-3,-1,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,78.399529532588,0,0\r\nPBStart=-27\r\n";
break;
case 114:
data="[#0114]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 115:
data="[#0115]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-8,-10,-9,-7,-6,-4,-3,-1,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-8,-10,-9,-7,-6,-4,-3,-1,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-8,-10,-9,-7,-6,-4,-3,-1,-1,0,0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,75.3688076376737,0,0\r\nPBStart=-27\r\n";
break;
case 116:
data="[#0116]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-9,-8,-6,-5,-3,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-9,-8,-6,-5,-3,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-7,-9,-9,-8,-6,-5,-3,-2,-1,0,0\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,59.6094552474602,0,0\r\nPBStart=0\r\n";
break;
case 117:
data="[#0117]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,4,5,5,4,3,1,-1,-2,-2,-2,-2,-1,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,83.2730136982746,0,0\r\nPBStart=0\r\n";
break;
case 118:
data="[#0118]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,10,8,7,5,3,2,1,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,10,8,7,5,3,2,1,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,5,7,9,10,8,7,5,3,2,1,0,0,0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,1.87583568313289,0,0\r\nPBStart=0\r\n";
break;
case 119:
data="[#0119]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 120:
data="[#0120]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-5,-6,-5,-5,-3,-1,1,2,2,3,2,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-5,-6,-5,-5,-3,-1,1,2,2,3,2,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-5,-6,-5,-5,-3,-1,1,2,2,3,2,2,1,0,0\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,7.39533325150036,0,0\r\nPBStart=-100\r\n";
break;
case 121:
data="[#0121]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,8,7,6,5,3,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,8,7,6,5,3,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,5,7,9,8,7,6,5,3,2,1,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,10.5452656633661,0,0\r\nPBStart=0\r\n";
break;
case 122:
data="[#0122]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-4,-5,-5,-4,-3,-1,1,2,2,2,2,1,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-4,-5,-5,-4,-3,-1,1,2,2,2,2,1,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-4,-5,-5,-4,-3,-1,1,2,2,2,2,1,0,0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,33.1694438717833,0,0\r\nPBStart=0\r\n";
break;
case 123:
data="[#0123]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,107,142,179,218,259,300,340,375,407,435,459,477,491,498,500,500\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,107,142,179,218,259,300,340,375,407,435,459,477,491,498,500,500\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,107,142,179,218,259,300,340,375,407,435,459,477,491,498,500,500\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,12.8249883376524,0,0\r\nPBStart=0\r\n";
break;
case 124:
data="[#0124]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 125:
data="[#0125]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-60,-86,-115,-147,-180,-213,-246,-278\r\nPitches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-60,-86,-115,-147,-180,-213,-246,-278\r\nPitchBend=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-60,-86,-115,-147,-180,-213,-246,-278\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 126:
data="[#0126]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=400,400,400,400,400,400,399,392,379,362,340,314,285,254,221,187,154,122,92,66,43,24,11,3,0\r\nPitches=400,400,400,400,400,400,399,392,379,362,340,314,285,254,221,187,154,122,92,66,43,24,11,3,0\r\nPitchBend=400,400,400,400,400,400,399,392,379,362,340,314,285,254,221,187,154,122,92,66,43,24,11,3,0\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 127:
data="[#0127]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,93,122,152,184,216,247,278,306,333,356,374,388,397,400,400\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,93,122,152,184,216,247,278,306,333,356,374,388,397,400,400\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,93,122,152,184,216,247,278,306,333,356,374,388,397,400,400\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,54.4013980598301,0,0\r\nPBStart=-100\r\n";
break;
case 128:
data="[#0128]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-59,-84,-112,-142,-175,-210,-244,-278,-310,-337,-361,-378,-392,-399,-400,-400\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-59,-84,-112,-142,-175,-210,-244,-278,-310,-337,-361,-378,-392,-399,-400,-400\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-38,-59,-84,-112,-142,-175,-210,-244,-278,-310,-337,-361,-378,-392,-399,-400,-400\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=33,130,10,50,50,82.7411848131011,0,0\r\nPBStart=0\r\n";
break;
case 129:
data="[#0129]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,47,67,88,109,128,145,162,175,186,195,199,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,47,67,88,109,128,145,162,175,186,195,199,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,17,30,47,67,88,109,128,145,162,175,186,195,199,200,200\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=33,130,10,50,50,8.18935602343773,0,0\r\nPBStart=0\r\n";
break;
case 130:
data="[#0130]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 131:
data="[#0131]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 132:
data="[#0132]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-18,-26,-35,-44,-52,-62,-72,-81,-89,-95,-98,-100,-100\r\nPitches=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-18,-26,-35,-44,-52,-62,-72,-81,-89,-95,-98,-100,-100\r\nPitchBend=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-7,-12,-18,-26,-35,-44,-52,-62,-72,-81,-89,-95,-98,-100,-100\r\nEnvelope=0,12,55,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=33,130,10,50,50,45.4207845424315,0,0\r\nPBStart=-24\r\n";
break;
case 133:
data="[#0133]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183,-193\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 134:
data="[#0134]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-5,-13,-25,-39,-56,-77,-98,-120,-140,-158,-173,-186\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-5,-13,-25,-39,-56,-77,-98,-120,-140,-158,-173,-186\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-5,-13,-25,-39,-56,-77,-98,-120,-140,-158,-173,-186\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,14.9981078858305,0,0\r\nPBStart=-24\r\n";
break;
case 135:
data="[#0135]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=8,2,0\r\nPitches=8,2,0\r\nPitchBend=8,2,0\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 136:
data="[#0136]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 137:
data="[#0137]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-10,-15,-23,-32,-40,-49,-59,-67,-77,-85,-91,-97,-100,-100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-10,-15,-23,-32,-40,-49,-59,-67,-77,-85,-91,-97,-100,-100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-5,-10,-15,-23,-32,-40,-49,-59,-67,-77,-85,-91,-97,-100,-100\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,53.0212520906419,0,0\r\nPBStart=-27\r\n";
break;
case 138:
data="[#0138]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 139:
data="[#0139]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,92,122,154,189,224,259,291,321,347,368,384,394,400,400,400\r\nPitches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,92,122,154,189,224,259,291,321,347,368,384,394,400,400,400\r\nPitchBend=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,25,43,66,92,122,154,189,224,259,291,321,347,368,384,394,400,400,400\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,75.7729271635661,0,0\r\nPBStart=-56.738\r\n";
break;
case 140:
data="[#0140]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 141:
data="[#0141]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-11,-22,-36,-52,-71,-90,-110,-129,-148,-164,-178,-189,-196\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-11,-22,-36,-52,-71,-90,-110,-129,-148,-164,-178,-189,-196\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-11,-22,-36,-52,-71,-90,-110,-129,-148,-164,-178,-189,-196\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-27\r\n";
break;
case 142:
data="[#0142]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,5,15,27,43,61,82,103,125,145,163,177,189,196,200,200,200\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,5,15,27,43,61,82,103,125,145,163,177,189,196,200,200,200\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,1,5,15,27,43,61,82,103,125,145,163,177,189,196,200,200,200\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,49.216563515378,0,0\r\nPBStart=-24\r\n";
break;
case 143:
data="[#0143]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 144:
data="[#0144]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-11,-26,-45,-68,-94,-122,-153,-185,-216,-248,-279,-308,-335,-359,-377,-390,-398,-400,-400\r\nPitches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-11,-26,-45,-68,-94,-122,-153,-185,-216,-248,-279,-308,-335,-359,-377,-390,-398,-400,-400\r\nPitchBend=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-11,-26,-45,-68,-94,-122,-153,-185,-216,-248,-279,-308,-335,-359,-377,-390,-398,-400,-400\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,32.9735919918827,0,0\r\nPBStart=-24\r\n";
break;
case 145:
data="[#0145]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 146:
data="[#0146]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,2,-2,-10,-23,-38,-56,-76,-98,-120,-140,-158,-173,-186,-195,-199,-200,-200\r\nPitches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,2,-2,-10,-23,-38,-56,-76,-98,-120,-140,-158,-173,-186,-195,-199,-200,-200\r\nPitchBend=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,2,-2,-10,-23,-38,-56,-76,-98,-120,-140,-158,-173,-186,-195,-199,-200,-200\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,58.9792564600403,0,0\r\nPBStart=-100\r\n";
break;
case 147:
data="[#0147]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367,400,429,454,474,489\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367,400,429,454,474,489\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,15,30,52,78,108,142,178,216,255,294,332,367,400,429,454,474,489\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 148:
data="[#0148]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nPitches=-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nPitchBend=-12,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 149:
data="[#0149]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,5,6,6,6,2,-7,-20,-34,-51,-70,-90,-108,-127,-145,-162,-176\r\nPitches=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,5,6,6,6,2,-7,-20,-34,-51,-70,-90,-108,-127,-145,-162,-176\r\nPitchBend=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,4,5,6,6,6,2,-7,-20,-34,-51,-70,-90,-108,-127,-145,-162,-176\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,9.79298388499394,0,0\r\nPBStart=-56.738\r\n";
break;
case 150:
data="[#0150]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-8,-16,-26,-39,-54,-71,-88,-107,-126,-145,-162,-176,-189\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-8,-16,-26,-39,-54,-71,-88,-107,-126,-145,-162,-176,-189\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-3,-4,-8,-16,-26,-39,-54,-71,-88,-107,-126,-145,-162,-176,-189\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,44.3862499397955,0,0\r\nPBStart=-27\r\n";
break;
case 151:
data="[#0151]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nPitches=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nPitchBend=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-13,-22,-31,-42,-53\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 152:
data="[#0152]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,0,4,10,19,28,38,48,58,68,77,85,91,96\r\nPitches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,0,4,10,19,28,38,48,58,68,77,85,91,96\r\nPitchBend=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,-1,0,4,10,19,28,38,48,58,68,77,85,91,96\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,87.2546876531317,0,0\r\nPBStart=-100\r\n";
break;
case 153:
data="[#0153]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nPitches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nPitchBend=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 154:
data="[#0154]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-18,-33,-52,-74,-99,-125,-153,-180\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-18,-33,-52,-74,-99,-125,-153,-180\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-18,-33,-52,-74,-99,-125,-153,-180\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-56.738\r\n";
break;
case 155:
data="[#0155]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=268,249,227,203,176,149,122,96,71,50,31,16,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,8,20,38,62,90,121,156,193,232,271,309,346\r\nPitches=268,249,227,203,176,149,122,96,71,50,31,16,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,8,20,38,62,90,121,156,193,232,271,309,346\r\nPitchBend=268,249,227,203,176,149,122,96,71,50,31,16,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,8,20,38,62,90,121,156,193,232,271,309,346\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-56.738\r\n";
break;
case 156:
data="[#0156]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,1,-5,-15,-28,-44,-63,-85,-106,-127,-146,-164,-178,-190,-196,-200,-200,-200\r\nPitches=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,1,-5,-15,-28,-44,-63,-85,-106,-127,-146,-164,-178,-190,-196,-200,-200,-200\r\nPitchBend=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,1,-5,-15,-28,-44,-63,-85,-106,-127,-146,-164,-178,-190,-196,-200,-200,-200\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=33,130,10,50,50,25.6628933219353,0,0\r\nPBStart=-56.738\r\n";
break;
case 157:
data="[#0157]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 158:
data="[#0158]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-7,-2,9,24,41,60,80,100,120,139,156,171,184,193\r\nPitches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-7,-2,9,24,41,60,80,100,120,139,156,171,184,193\r\nPitchBend=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-4,-5,-7,-8,-7,-2,9,24,41,60,80,100,120,139,156,171,184,193\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,3.09506061678046,0,0\r\nPBStart=-100\r\n";
break;
case 159:
data="[#0159]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,2,8,19,33,51,69,92,112,131,150,166,178,189,196,200,200,200\r\nPitches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,2,8,19,33,51,69,92,112,131,150,166,178,189,196,200,200,200\r\nPitchBend=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,2,8,19,33,51,69,92,112,131,150,166,178,189,196,200,200,200\r\nEnvelope=0,12,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,32.2717672873667,0,0\r\nPBStart=-24\r\n";
break;
case 160:
data="[#0160]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-39,-61,-87,-116,-147,-180,-214,-247,-279,-309,-335,-358,-376\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-39,-61,-87,-116,-147,-180,-214,-247,-279,-309,-335,-358,-376\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-9,-21,-39,-61,-87,-116,-147,-180,-214,-247,-279,-309,-335,-358,-376\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 161:
data="[#0161]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=107,79,54,33,17,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,4,12,24,40,59,78,97,116,134,152,167,179,189\r\nPitches=107,79,54,33,17,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,4,12,24,40,59,78,97,116,134,152,167,179,189\r\nPitchBend=107,79,54,33,17,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,4,12,24,40,59,78,97,116,134,152,167,179,189\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=33,130,10,49,49,29.7258028905958,0,0\r\nPBStart=-27\r\n";
break;
case 162:
data="[#0162]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119\r\nPitches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119\r\nPitchBend=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 163:
data="[#0163]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,15,31,53,79,109,143,179,217,256,295,333,368\r\nPitches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,15,31,53,79,109,143,179,217,256,295,333,368\r\nPitchBend=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,15,31,53,79,109,143,179,217,256,295,333,368\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 164:
data="[#0164]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,2,-3,-11,-21,-33,-45,-57,-70,-79,-88,-95,-98,-101,-100,-100\r\nPitches=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,2,-3,-11,-21,-33,-45,-57,-70,-79,-88,-95,-98,-101,-100,-100\r\nPitchBend=-381,-346,-309,-271,-232,-193,-156,-121,-89,-62,-38,-20,-8,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,4,4,2,-3,-11,-21,-33,-45,-57,-70,-79,-88,-95,-98,-101,-100,-100\r\nEnvelope=0,16.9,55,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=33,130,10,50,50,25.4601903828422,0,0\r\nPBStart=-56.738\r\n";
break;
case 165:
data="[#0165]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119,-138,-156,-171,-183\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 166:
data="[#0166]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,-1,-7,-17,-30,-46,-66,-86,-108,-129,-149,-166,-180,-191,-197,-200,-200\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,-1,-7,-17,-30,-46,-66,-86,-108,-129,-149,-166,-180,-191,-197,-200,-200\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,-1,-7,-17,-30,-46,-66,-86,-108,-129,-149,-166,-180,-191,-197,-200,-200\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,4.49338556133143,0,0\r\nPBStart=-27\r\n";
break;
case 167:
data="[#0167]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-7,-9,-9,-8,-6,-4,-2,-1,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-7,-9,-9,-8,-6,-4,-2,-1,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-6,-7,-9,-9,-8,-6,-4,-2,-1,0,0,0,0\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,48.2428062127066,0,0\r\nPBStart=0\r\n";
break;
case 168:
data="[#0168]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=65,165,20,20,20,0,0,50\r\n";
break;
case 169:
data="[#0169]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-6,-10,-16,-25,-35,-44,-52,-61,-70,-78,-86,-93,-96,-100,-100,-100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-6,-10,-16,-25,-35,-44,-52,-61,-70,-78,-86,-93,-96,-100,-100,-100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-6,-10,-16,-25,-35,-44,-52,-61,-70,-78,-86,-93,-96,-100,-100,-100\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,50,50,86.4534533397956,0,0\r\nPBStart=-56.738\r\n";
break;
case 170:
data="[#0170]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,10,17,24,33,44,57,68,79,87,94,98,100,100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,10,17,24,33,44,57,68,79,87,94,98,100,100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,10,17,24,33,44,57,68,79,87,94,98,100,100\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,58.8628586529347,0,0\r\nPBStart=0\r\n";
break;
case 171:
data="[#0171]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,21,39,61,87,116,147,180,214,247,279,309,335,358,376,390\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,21,39,61,87,116,147,180,214,247,279,309,335,358,376,390\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,21,39,61,87,116,147,180,214,247,279,309,335,358,376,390\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 172:
data="[#0172]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-11,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119,-138,-155,-171,-183,-193\r\nPitches=-11,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119,-138,-155,-171,-183,-193\r\nPitchBend=-11,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-7,-16,-28,-43,-61,-79,-99,-119,-138,-155,-171,-183,-193\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 173:
data="[#0173]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 174:
data="[#0174]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,11,22,36,52,71,90,110\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,11,22,36,52,71,90,110\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,11,22,36,52,71,90,110\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-27\r\n";
break;
case 175:
data="[#0175]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,10,21,34,50,68,88,107\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,10,21,34,50,68,88,107\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,10,21,34,50,68,88,107\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-56.738\r\n";
break;
case 176:
data="[#0176]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-5,-15,-31,-50,-74,-100,-129,-160,-192,-223,-255,-286,-315,-340,-362,-379,-391,-398,-400,-400\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-5,-15,-31,-50,-74,-100,-129,-160,-192,-223,-255,-286,-315,-340,-362,-379,-391,-398,-400,-400\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-5,-15,-31,-50,-74,-100,-129,-160,-192,-223,-255,-286,-315,-340,-362,-379,-391,-398,-400,-400\r\nEnvelope=0,22.9,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,63.4371919166233,0,0\r\nPBStart=-56.738\r\n";
break;
case 177:
data="[#0177]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=78\r\nPBS=-78\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 178:
data="[#0178]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186,-194\r\nPitches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186,-194\r\nPitchBend=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-9,-19,-32,-48,-65,-85,-104,-124,-143,-160,-174,-186,-194\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 179:
data="[#0179]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nPitches=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nPitchBend=58,41,27,15,6,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,6,18,35,58,85,116,151,187,226,265,303,341,376,408,436,460,478,491\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 180:
data="[#0180]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,-5,-13,-23,-35,-48,-59,-71,-81,-89,-95,-99,-100,-100,-100\r\nPitches=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,-5,-13,-23,-35,-48,-59,-71,-81,-89,-95,-99,-100,-100,-100\r\nPitchBend=-94,-66,-42,-23,-9,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,0,-5,-13,-23,-35,-48,-59,-71,-81,-89,-95,-99,-100,-100,-100\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=33,130,10,50,50,92.3445142662288,0,0\r\nPBStart=-24\r\n";
break;
case 181:
data="[#0181]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-29,-46,-65,-86,-108,-127,-145,-162,-176,-186,-195,-199,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-29,-46,-65,-86,-108,-127,-145,-162,-176,-186,-195,-199,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-29,-46,-65,-86,-108,-127,-145,-162,-176,-186,-195,-199,-200,-200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,62.0209559867707,0,0\r\nPBStart=0\r\n";
break;
case 182:
data="[#0182]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 183:
data="[#0183]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nPitches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nPitchBend=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-7,-14,-22,-32,-42,-53\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 184:
data="[#0184]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nPitches=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nPitchBend=100,100,100,100,100,100,100,100,100,100,100,98,93,87,79,69,58,48,37,27,18,10,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,47.9978262999259,0,0\r\nPBStart=-100\r\n";
break;
case 185:
data="[#0185]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 186:
data="[#0186]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-8,-20,-35,-55,-77,-102,-129,-156,-183,-209,-233,-254,-272\r\nPitches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-8,-20,-35,-55,-77,-102,-129,-156,-183,-209,-233,-254,-272\r\nPitchBend=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-8,-20,-35,-55,-77,-102,-129,-156,-183,-209,-233,-254,-272\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-27\r\n";
break;
case 187:
data="[#0187]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=61\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,22,41,66,96,130,166,205,245,284,322,357,389,418,444,466,482,493,499,500\r\nPitches=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,22,41,66,96,130,166,205,245,284,322,357,389,418,444,466,482,493,499,500\r\nPitchBend=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,22,41,66,96,130,166,205,245,284,322,357,389,418,444,466,482,493,499,500\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,13.0420451090138,0,0\r\nPBStart=-27\r\n";
break;
case 188:
data="[#0188]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-16,-28,-43,-61,-80,-99,-119\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=84\r\nPBS=-84\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 189:
data="[#0189]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,1,-1,-8,-18,-33,-50,-68,-87,-106,-125,-143,-159,-173,-185,-193\r\nPitches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,1,-1,-8,-18,-33,-50,-68,-87,-106,-125,-143,-159,-173,-185,-193\r\nPitchBend=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,1,-1,-8,-18,-33,-50,-68,-87,-106,-125,-143,-159,-173,-185,-193\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,34.5391624188386,0,0\r\nPBStart=-100\r\n";
break;
case 190:
data="[#0190]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=62\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,12,23,36,53,70,90,112,133,151,169,182,193,198,200,200\r\nPitches=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,12,23,36,53,70,90,112,133,151,169,182,193,198,200,200\r\nPitchBend=8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,12,23,36,53,70,90,112,133,151,169,182,193,198,200,200\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,54.7668511259212,0,0\r\nPBStart=-8.42\r\n";
break;
case 191:
data="[#0191]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 192:
data="[#0192]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,8,15,24,34,45,55\r\nPitches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,8,15,24,34,45,55\r\nPitchBend=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,8,15,24,34,45,55\r\nEnvelope=0,12,67.2,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 193:
data="[#0193]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,8,16,28,41,56,74,93,113,133,151,167,181,191,197,200,200\r\nPitches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,8,16,28,41,56,74,93,113,133,151,167,181,191,197,200,200\r\nPitchBend=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,4,8,16,28,41,56,74,93,113,133,151,167,181,191,197,200,200\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,40.6421299642715,0,0\r\nPBStart=-100\r\n";
break;
case 194:
data="[#0194]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-40,-60,-84,-110,-137,-165,-194,-221,-244,-265,-281,-293,-299,-300,-300\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-40,-60,-84,-110,-137,-165,-194,-221,-244,-265,-281,-293,-299,-300,-300\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-40,-60,-84,-110,-137,-165,-194,-221,-244,-265,-281,-293,-299,-300,-300\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,84.7245503224875,0,0\r\nPBStart=0\r\n";
break;
case 195:
data="[#0195]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,11,19,27,35,45,54,63,72,80,87,94,98,100,100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,11,19,27,35,45,54,63,72,80,87,94,98,100,100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,11,19,27,35,45,54,63,72,80,87,94,98,100,100\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,82.622552016317,0,0\r\nPBStart=0\r\n";
break;
case 196:
data="[#0196]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,8,17,29,42,59,76,93,112,131,150,166,179,191,197,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,8,17,29,42,59,76,93,112,131,150,166,179,191,197,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,8,17,29,42,59,76,93,112,131,150,166,179,191,197,200,200\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,67.2427570328307,0,0\r\nPBStart=0\r\n";
break;
case 197:
data="[#0197]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 198:
data="[#0198]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=10,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,13,22,31,42,53\r\nPitches=10,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,13,22,31,42,53\r\nPitchBend=10,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,13,22,31,42,53\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 199:
data="[#0199]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,7,15,27,41,58,76,95,112,130,147,162,175,187,194,199,200,200\r\nPitches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,7,15,27,41,58,76,95,112,130,147,162,175,187,194,199,200,200\r\nPitchBend=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,7,15,27,41,58,76,95,112,130,147,162,175,187,194,199,200,200\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,33.9806085212626,0,0\r\nPBStart=-56.738\r\n";
break;
case 200:
data="[#0200]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-28,-47,-69,-95,-122,-151,-179,-204,-227,-247,-265,-280,-291,-298,-300,-300\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-28,-47,-69,-95,-122,-151,-179,-204,-227,-247,-265,-280,-291,-298,-300,-300\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-28,-47,-69,-95,-122,-151,-179,-204,-227,-247,-265,-280,-291,-298,-300,-300\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,49.521129239568,0,0\r\nPBStart=0\r\n";
break;
case 201:
data="[#0201]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 202:
data="[#0202]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nPitches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nPitchBend=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 203:
data="[#0203]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-1,-2,-4,-6,-10,-15,-24,-36,-49,-65,-82,-101,-120,-139,-156,-171,-184\r\nPitches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-1,-2,-4,-6,-10,-15,-24,-36,-49,-65,-82,-101,-120,-139,-156,-171,-184\r\nPitchBend=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,-1,-2,-4,-6,-10,-15,-24,-36,-49,-65,-82,-101,-120,-139,-156,-171,-184\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,17.9089305530522,0,0\r\nPBStart=-100\r\n";
break;
case 204:
data="[#0204]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-5,-8,-12,-19,-26,-34,-45,-55,-66,-76,-85,-93\r\nPitches=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-5,-8,-12,-19,-26,-34,-45,-55,-66,-76,-85,-93\r\nPitchBend=72,53,37,23,12,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-4,-5,-8,-12,-19,-26,-34,-45,-55,-66,-76,-85,-93\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,42.2918255545046,0,0\r\nPBStart=-27\r\n";
break;
case 205:
data="[#0205]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,0,4,12,23,35,48,59,71,81,90,96\r\nPitches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,0,4,12,23,35,48,59,71,81,90,96\r\nPitchBend=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-3,0,4,12,23,35,48,59,71,81,90,96\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,54.3177016806507,0,0\r\nPBStart=-8.42\r\n";
break;
case 206:
data="[#0206]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nPitches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nPitchBend=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,7,16,28,43,61,79,99,119\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 207:
data="[#0207]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-8,-19,-33,-51,-71,-94,-118,-145,-172,-199,-224,-247,-267,-282,-293,-299,-300,-300\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-8,-19,-33,-51,-71,-94,-118,-145,-172,-199,-224,-247,-267,-282,-293,-299,-300,-300\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-8,-19,-33,-51,-71,-94,-118,-145,-172,-199,-224,-247,-267,-282,-293,-299,-300,-300\r\nEnvelope=0,22.9,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,54.0913568006555,0,0\r\nPBStart=-56.738\r\n";
break;
case 208:
data="[#0208]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-1,2,8,15,23,34,47,60,72,83,90,97,100,100,100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-1,2,8,15,23,34,47,60,72,83,90,97,100,100,100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-1,2,8,15,23,34,47,60,72,83,90,97,100,100,100\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,42.7533338476233,0,0\r\nPBStart=0\r\n";
break;
case 209:
data="[#0209]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,14,24,37,54,71,89,111,132,151,168,182,193,198,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,14,24,37,54,71,89,111,132,151,168,182,193,198,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,14,24,37,54,71,89,111,132,151,168,182,193,198,200,200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,50.9068114565334,0,0\r\nPBStart=0\r\n";
break;
case 210:
data="[#0210]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 211:
data="[#0211]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,2,8,16,25,38,50,63,74,85,92,98,99,100,100\r\nPitches=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,2,8,16,25,38,50,63,74,85,92,98,99,100,100\r\nPitchBend=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,-2,2,8,16,25,38,50,63,74,85,92,98,99,100,100\r\nEnvelope=0,12,52.3,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,61.9187611785892,0,0\r\nPBStart=-24\r\n";
break;
case 212:
data="[#0212]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,13,24,37,54,71,89,111,132,152,169,182,193,198,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,13,24,37,54,71,89,111,132,152,169,182,193,198,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,13,24,37,54,71,89,111,132,152,169,182,193,198,200,200\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,48.9830431422048,0,0\r\nPBStart=0\r\n";
break;
case 213:
data="[#0213]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-27,-44,-65,-89,-115,-142,-169,-196,-221,-243,-263,-279,-291\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 214:
data="[#0214]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,9,15,23,31,40,49,60,71,81,89,95,98,100,100\r\nPitches=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,9,15,23,31,40,49,60,71,81,89,95,98,100,100\r\nPitchBend=75,53,34,18,8,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,5,9,15,23,31,40,49,60,71,81,89,95,98,100,100\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,88.6600066639609,0,0\r\nPBStart=-24\r\n";
break;
case 215:
data="[#0215]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,12,23,37,55,74,94,116,137,156,172,185,195,199,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,12,23,37,55,74,94,116,137,156,172,185,195,199,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,5,12,23,37,55,74,94,116,137,156,172,185,195,199,200,200\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,37.0515336685416,0,0\r\nPBStart=0\r\n";
break;
case 216:
data="[#0216]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-47,-69,-93,-119,-145,-170,-195,-219,-240,-260,-276,-289,-297,-300,-300\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-47,-69,-93,-119,-145,-170,-195,-219,-240,-260,-276,-289,-297,-300,-300\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-47,-69,-93,-119,-145,-170,-195,-219,-240,-260,-276,-289,-297,-300,-300\r\nEnvelope=0,7.1,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,30.2497561882014,0,0\r\nPBStart=0\r\n";
break;
case 217:
data="[#0217]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 218:
data="[#0218]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nPitches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nPitchBend=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,29,44,61,80,100,120\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-100\r\n";
break;
case 219:
data="[#0219]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,2,-3,-11,-25,-40,-59,-80,-101,-123,-142,-160,-175,-187,-195,-199,-200,-200\r\nPitches=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,2,-3,-11,-25,-40,-59,-80,-101,-123,-142,-160,-175,-187,-195,-199,-200,-200\r\nPitchBend=-200,-200,-200,-200,-200,-200,-200,-200,-200,-199,-193,-184,-172,-157,-140,-121,-101,-81,-62,-45,-29,-17,-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,3,2,-3,-11,-25,-40,-59,-80,-101,-123,-142,-160,-175,-187,-195,-199,-200,-200\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,52.9821151066978,0,0\r\nPBStart=-100\r\n";
break;
case 220:
data="[#0220]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53\r\nEnvelope=0,26.8,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 221:
data="[#0221]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-6,-6,-6,-5,-1,3,10,19,28,38,47,57,68,77,86\r\nPitches=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-6,-6,-6,-5,-1,3,10,19,28,38,47,57,68,77,86\r\nPitchBend=99,96,91,84,75,65,54,44,33,23,15,8,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-5,-6,-6,-6,-5,-1,3,10,19,28,38,47,57,68,77,86\r\nEnvelope=0,16.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,58.4529296716982,0,0\r\nPBStart=-56.738\r\n";
break;
case 222:
data="[#0222]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,2,9,21,37,55,75,95,115,134,152,167,180,189\r\nPitches=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,2,9,21,37,55,75,95,115,134,152,167,180,189\r\nPitchBend=-42,-32,-22,-14,-7,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-2,2,9,21,37,55,75,95,115,134,152,167,180,189\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,36.3458688798922,0,0\r\nPBStart=-27\r\n";
break;
case 223:
data="[#0223]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195\r\nPitches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195\r\nPitchBend=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195\r\nEnvelope=0,5,67.2,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 224:
data="[#0224]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=300,300,300,300,300,300,300,300,296,287,274,257,236,212,186,159,132,105,80,57,37,21,10,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nPitches=300,300,300,300,300,300,300,300,296,287,274,257,236,212,186,159,132,105,80,57,37,21,10,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nPitchBend=300,300,300,300,300,300,300,300,296,287,274,257,236,212,186,159,132,105,80,57,37,21,10,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,3,3,6,9,15,21,29,38,48,59,69,79,87,94,98,100,100\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,49,49,47.8014166212431,0,0\r\nPBStart=-100\r\n";
break;
case 225:
data="[#0225]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119,138,156,171,183,193\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 226:
data="[#0226]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-33,-53,-76,-102,-129,-158,-185,-209,-232,-253,-269,-283,-293,-299,-300,-300\r\nPitches=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-33,-53,-76,-102,-129,-158,-185,-209,-232,-253,-269,-283,-293,-299,-300,-300\r\nPitchBend=-58,-41,-27,-15,-6,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-33,-53,-76,-102,-129,-158,-185,-209,-232,-253,-269,-283,-293,-299,-300,-300\r\nEnvelope=0,12,52.3,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,68.4062266342488,0,0\r\nPBStart=-24\r\n";
break;
case 227:
data="[#0227]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 228:
data="[#0228]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,7,14,24,37,52,67,84,102,121,139,155,170,183,193\r\nPitches=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,7,14,24,37,52,67,84,102,121,139,155,170,183,193\r\nPitchBend=-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-100,-98,-93,-87,-79,-69,-58,-48,-37,-27,-18,-10,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,7,14,24,37,52,67,84,102,121,139,155,170,183,193\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,61.3934930695684,0,0\r\nPBStart=-100\r\n";
break;
case 229:
data="[#0229]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195,-220,-243,-263,-279\r\nPitches=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195,-220,-243,-263,-279\r\nPitchBend=-8,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-13,-26,-44,-65,-88,-114,-141,-168,-195,-220,-243,-263,-279\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-8.42\r\n";
break;
case 230:
data="[#0230]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,17,26,36,46,55,64,72,81,88,93,98,100,100\r\nPitches=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,17,26,36,46,55,64,72,81,88,93,98,100,100\r\nPitchBend=93,68,47,29,15,5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,17,26,36,46,55,64,72,81,88,93,98,100,100\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,16.1743698623816,0,0\r\nPBStart=-27\r\n";
break;
case 231:
data="[#0231]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,65,83,100,119,136,153,168,180,191,197,200,200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,65,83,100,119,136,153,168,180,191,197,200,200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,47,65,83,100,119,136,153,168,180,191,197,200,200\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,80.7779759508653,0,0\r\nPBStart=0\r\n";
break;
case 232:
data="[#0232]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-46,-66,-90,-114,-139,-164,-190,-215,-237,-258,-275,-289,-297,-300,-300\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-46,-66,-90,-114,-139,-164,-190,-215,-237,-258,-275,-289,-297,-300,-300\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-14,-29,-46,-66,-90,-114,-139,-164,-190,-215,-237,-258,-275,-289,-297,-300,-300\r\nEnvelope=0,14.2,37.7,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,20.2618301665588,0,0\r\nPBStart=0\r\n";
break;
case 233:
data="[#0233]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 234:
data="[#0234]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,19,33,50,69,88,108,127,144,159,174,184,193,198,200,200\r\nPitches=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,19,33,50,69,88,108,127,144,159,174,184,193,198,200,200\r\nPitchBend=-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,9,19,33,50,69,88,108,127,144,159,174,184,193,198,200,200\r\nEnvelope=0,5,52.3,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,6.58510348416368,0,0\r\nPBStart=-8.42\r\n";
break;
case 235:
data="[#0235]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-15,-25,-39,-55,-72,-89,-110,-131,-150,-167,-181,-192,-198,-200,-200\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-15,-25,-39,-55,-72,-89,-110,-131,-150,-167,-181,-192,-198,-200,-200\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-15,-25,-39,-55,-72,-89,-110,-131,-150,-167,-181,-192,-198,-200,-200\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,6.15222459299727,0,0\r\nPBStart=0\r\n";
break;
case 236:
data="[#0236]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-7,-14,-22,-31,-42,-53,-64,-74,-83,-90,-96\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 237:
data="[#0237]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-2,2,8,17,27,40,53,64,75,85,93,98,100,100,100\r\nPitches=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-2,2,8,17,27,40,53,64,75,85,93,98,100,100,100\r\nPitchBend=5,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-2,-3,-2,2,8,17,27,40,53,64,75,85,93,98,100,100,100\r\nEnvelope=0,5,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,37.9604686814401,0,0\r\nPBStart=-8.42\r\n";
break;
case 238:
data="[#0238]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nEnvelope=0,28.3,37.7,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 239:
data="[#0239]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-5,-15,-30,-50,-73,-100,-128,-157,-185,-212,-235,-257,-274,-287,-296,-299,-300,-300\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-5,-15,-30,-50,-73,-100,-128,-157,-185,-212,-235,-257,-274,-287,-296,-299,-300,-300\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,-5,-15,-30,-50,-73,-100,-128,-157,-185,-212,-235,-257,-274,-287,-296,-299,-300,-300\r\nEnvelope=0,22.9,52.3,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,11.9544029396688,0,0\r\nPBStart=-56.738\r\n";
break;
case 240:
data="[#0240]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53,64,74,83,90,96\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 241:
data="[#0241]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-35,-25,-16,-9,-4,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,48,65,85,104,124,143,160,174,186\r\nPitches=-35,-25,-16,-9,-4,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,48,65,85,104,124,143,160,174,186\r\nPitchBend=-35,-25,-16,-9,-4,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,9,19,32,48,65,85,104,124,143,160,174,186\r\nEnvelope=0,12,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-24\r\n";
break;
case 242:
data="[#0242]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-31,-50,-71,-96,-124,-152,-181,-209,-234,-256,-274,-288,-296,-300,-300\r\nPitches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-31,-50,-71,-96,-124,-152,-181,-209,-234,-256,-274,-288,-296,-300,-300\r\nPitchBend=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-6,-17,-31,-50,-71,-96,-124,-152,-181,-209,-234,-256,-274,-288,-296,-300,-300\r\nEnvelope=0,10,35,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,4.81188914029644,0,0\r\nPBStart=-27\r\n";
break;
case 243:
data="[#0243]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,5,54.8,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 244:
data="[#0244]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-4,-4,-4,-3,1,10,23,37,53,71,90,108,127,145,162,176\r\nPitches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-4,-4,-4,-3,1,10,23,37,53,71,90,108,127,145,162,176\r\nPitchBend=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,-3,-4,-4,-4,-4,-3,1,10,23,37,53,71,90,108,127,145,162,176\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,49,49,53.3022346894476,0,0\r\nPBStart=-56.738\r\n";
break;
case 245:
data="[#0245]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-23,-39,-60,-83,-108,-135,-161,-186,-210,-233,-253,-270,-284,-294,-300,-300\r\nPitches=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-23,-39,-60,-83,-108,-135,-161,-186,-210,-233,-253,-270,-284,-294,-300,-300\r\nPitchBend=-72,-53,-37,-23,-12,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-23,-39,-60,-83,-108,-135,-161,-186,-210,-233,-253,-270,-284,-294,-300,-300\r\nEnvelope=0,10,55,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,56.1009274691576,0,0\r\nPBStart=-27\r\n";
break;
case 246:
data="[#0246]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,14,22,31,42,53\r\nEnvelope=0,55,40.4,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 247:
data="[#0247]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,25,40,57,77,97,115,134,150,166,178,189,195,199,200,200\r\nPitches=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,25,40,57,77,97,115,134,150,166,178,189,195,199,200,200\r\nPitchBend=-99,-96,-91,-84,-75,-65,-54,-44,-33,-23,-15,-8,-3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,12,25,40,57,77,97,115,134,150,166,178,189,195,199,200,200\r\nEnvelope=0,22.9,35,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,46.8005662348639,0,0\r\nPBStart=-56.738\r\n";
break;
case 248:
data="[#0248]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-41,-62,-87,-114,-142,-171,-200,-225,-248,-267,-283,-293,-299,-300,-300\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-41,-62,-87,-114,-142,-171,-200,-225,-248,-267,-283,-293,-299,-300,-300\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,-12,-25,-41,-62,-87,-114,-142,-171,-200,-225,-248,-267,-283,-293,-299,-300,-300\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,50,50,74.6354729937866,0,0\r\nPBStart=0\r\n";
break;
case 249:
data="[#0249]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,16,24,31,40,50,60,70,79,87,94,98,100,100\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,16,24,31,40,50,60,70,79,87,94,98,100,100\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,5,10,16,24,31,40,50,60,70,79,87,94,98,100,100\r\nEnvelope=0,31.3,40.4,0,100,100,0\r\nPBW=72\r\nPBS=-72\r\nVBR=33,130,10,50,50,75.231088256709,0,0\r\nPBStart=0\r\n";
break;
case 250:
data="[#0250]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,7,16,28,43,61,80,99,119\r\nEnvelope=0,5,51,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 251:
data="[#0251]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=69\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107,-127\r\nPitches=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107,-127\r\nPitchBend=-190,-180,-167,-151,-133,-114,-94,-74,-56,-39,-24,-13,-5,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,-10,-21,-34,-50,-68,-88,-107,-127\r\nEnvelope=0,16.9,67.2,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=-56.738\r\n";
break;
case 252:
data="[#0252]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=67\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,2,5,7,4,0,-8,-17,-28,-40,-52,-64,-74,-83,-90,-96\r\nPitches=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,2,5,7,4,0,-8,-17,-28,-40,-52,-64,-74,-83,-90,-96\r\nPitchBend=200,200,200,200,200,200,200,200,200,199,193,184,172,157,140,121,101,81,62,45,29,17,8,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,-1,-1,0,1,2,5,7,4,0,-8,-17,-28,-40,-52,-64,-74,-83,-90,-96\r\nEnvelope=0,67.2,95,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=33,130,10,49,49,74.6006921527131,0,0\r\nPBStart=-100\r\n";
break;
case 253:
data="[#0253]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=66\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=35,25,16,9,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,-1,-6,-14,-26,-41,-57,-77,-98,-120,-141,-159,-174,-187,-195,-200,-200,-200\r\nPitches=35,25,16,9,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,-1,-6,-14,-26,-41,-57,-77,-98,-120,-141,-159,-174,-187,-195,-200,-200,-200\r\nPitchBend=35,25,16,9,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,-1,-6,-14,-26,-41,-57,-77,-98,-120,-141,-159,-174,-187,-195,-200,-200,-200\r\nEnvelope=0,12,52.3,0,100,100,0\r\nPBW=60\r\nPBS=-60\r\nVBR=33,130,10,50,50,8.85595118139728,0,0\r\nPBStart=-24\r\n";
break;
case 254:
data="[#0254]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0\r\nPitches=0\r\nPitchBend=0\r\nEnvelope=0,52.3,51,0,100,100,0\r\nPBW=66\r\nPBS=-66\r\nVBR=65,165,20,20,20,0,0,50\r\nPBStart=0\r\n";
break;
case 255:
data="[#0255]\r\nLength=240\r\nLyric="+py+"\r\nNoteNum=64\r\nPreUtterance=100\r\nVoiceOverlap=67.237\r\nIntensity=100\r\nModulation=0\r\nModuration=0\r\nPBType=5\r\nPiches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,5,7,8,9,9,7,5,4,2,1,0,0,0,0,0\r\nPitches=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,5,7,8,9,9,7,5,4,2,1,0,0,0,0,0\r\nPitchBend=0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,3,4,5,7,8,9,9,7,5,4,2,1,0,0,0,0,0\r\nEnvelope=0,51.3,95,0,100,100,0\r\nPBW=50\r\nPBS=-50\r\nVBR=33,130,10,49,49,71.3027960247651,0,0\r\nPBStart=-100\r\n";
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
