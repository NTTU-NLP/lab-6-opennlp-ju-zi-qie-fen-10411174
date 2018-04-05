using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using opennlp.tools.sentdetect;
using opennlp.tools.tokenize;

namespace _123
{
	class Program
	{
		static void Main(string[] args)
		{
			java.io.InputStream modelIn = new java.io.FileInputStream(string.Format("en-sent.bin"));
			java.io.InputStream modelIn2 = new java.io.FileInputStream(string.Format("en-token.bin"));
			TokenizerModel model = new TokenizerModel(modelIn2);
			TokenizerME mE = new TokenizerME(model);
			SentenceModel sM = new SentenceModel(modelIn);
			SentenceDetector detector = new SentenceDetectorME(sM);
			string folderName = @"C:\Users\Administrator\Desktop\lab-6-opennlp-ju-zi-qie-fen-10411174\file";
			foreach (string fname in System.IO.Directory.GetFiles(folderName))
			{
				String line = null;
				String[] name = fname.Split('\\');
				StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\lab-6-opennlp-ju-zi-qie-fen-10411174\answer\" + name[6]);
				StreamReader file2 = new StreamReader(fname);
				while ((line = file2.ReadLine()) != null)
				{
					string str = null;
					string[] sents = detector.sentDetect(line);
					if (sents.Length.Equals(0)){continue;}
					foreach (var s in sents){str = str +s;}
					var Tokens = mE.tokenize(str);
					foreach (var s in Tokens){sw.Write(s+" ");}sw.WriteLine();
				}sw.Close(); 
			}
		}
	}
}
