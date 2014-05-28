using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using ComponentAce.Compression.Libs.zlib;

namespace MTexasPokerFrame.Ciper.Utils
{
	public class Utils
	{
		// Singleton
		private static Utils _inst = null;
		public static Utils Inst
		{
			get
			{
				if (_inst == null)
				{
					_inst = new Utils();
				}
				return _inst;
			}
		}
		
		// 获取密钥 ONLHYIBNQWJIGCTD
		private static byte[] _key = null;
		public static byte[] Key
		{
			get
			{
				if (_key != null)
				{
					return _key;
				}
				byte[] key = new byte[16];
				
				for (int i = 0; i < 16; i++)
				{
					byte chr = (byte)(((int) Math.Abs(Math.Pow(2.0, i) - 65)) % 25 + 65);
					key[i] = chr;
				}
				
				if (_key == null)
				{
					_key = key;
				}
				
				return _key;
			}
		}
		
		public static string ToString(byte[] source)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			return encoding.GetString(source);
		}
		
		public static byte[] ToByte(string source)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			return encoding.GetBytes(source);
		}
		
		public static string EncodeBase64(byte[] source)
		{
			return Convert.ToBase64String(source);
		}
		
		public static byte[] DecodeBase64(string source)
		{
			return Convert.FromBase64String(source);
		}
		
		public static byte[] GetMD5(byte[] source)
		{
			MD5CryptoServiceProvider md5CSP = new MD5CryptoServiceProvider();
			return md5CSP.ComputeHash(source);
		}
		
		public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
		{
			const int size = 2000;
			byte[] buffer = new byte[size];
			int len = 0;
			while ((len = input.Read(buffer, 0, size)) > 0)
			{
				output.Write(buffer, 0, len);
			}
			output.Flush();
		}
		
		public static byte[] DecompressData(byte[] toDecompress)
		{
			MemoryStream outMemoryStream = new MemoryStream();
			ZOutputStream outZStream = new ZOutputStream(outMemoryStream, zlibConst.Z_DEFAULT_COMPRESSION);
			Stream inMemoryStream = new MemoryStream(toDecompress);
			
			CopyStream(inMemoryStream, outZStream);
			outZStream.finish();
			return outMemoryStream.ToArray();
		}
		
		
		public static byte[] CompressData(byte[] toCompress)
		{
			MemoryStream outMemoryStream = new MemoryStream();
			ZOutputStream outZStream = new ZOutputStream(outMemoryStream, zlibConst.Z_DEFAULT_COMPRESSION);
			Stream inMemoryStream = new MemoryStream(toCompress);
			
			CopyStream(inMemoryStream, outZStream);
			outZStream.finish();
			return outMemoryStream.ToArray();
		}
		
		public static byte[] encryptAES(byte[] toEncrypt, byte[] key)
		{
			RijndaelManaged rDel = new RijndaelManaged();
			rDel.Key = key;
			rDel.Mode = CipherMode.ECB;
			rDel.Padding = PaddingMode.None;
			
			ICryptoTransform cTransform = rDel.CreateEncryptor();
			return cTransform.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
		}
		
		public static byte[] DecryptAES(byte[] toDecrypt, byte[] key)
		{
			RijndaelManaged rDel = new RijndaelManaged();
			rDel.Key = key;
			rDel.Mode = CipherMode.ECB;
			rDel.Padding = PaddingMode.None;
			ICryptoTransform cTransform = rDel.CreateDecryptor();
			return cTransform.TransformFinalBlock(toDecrypt, 0, toDecrypt.Length);
		}
	}
}

