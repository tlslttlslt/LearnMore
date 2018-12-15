using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;   // 使用Dictionary类需要的命名空间。
using System.Linq;                           // 使用Linq查询类需要的命名空间。




namespace LXL.CommonClassLib
{
    public class TextOperation
    {
        /// <summary>
        /// 根据给定的编码，确定字符串的byte长度。如“Shift-JIS“
        /// </summary>
        /// <param name="str">要确定长度的字符串</param>
        /// <param name="charSetName">字符集的准确全称</param>
        /// <returns></returns>
        public static int GetStringLengthByByte(string str, string charSetName)
        {
            int byteLength;
            switch (charSetName)
            {
                case "UTF8":
                    byteLength = System.Text.Encoding.UTF8.GetBytes(str).Length;
                    break;
                case "Unicode":
                    byteLength = System.Text.Encoding.Unicode.GetBytes(str).Length;
                    break;
                case "ASCII":
                    byteLength = System.Text.Encoding.ASCII.GetBytes(str).Length;
                    break;
                case "UTF32":
                    byteLength = System.Text.Encoding.UTF32.GetBytes(str).Length;
                    break;
                case "BigEndianUnicode":
                    byteLength = System.Text.Encoding.BigEndianUnicode.GetBytes(str).Length;
                    break;
                case "UTF7":
                    byteLength = System.Text.Encoding.UTF7.GetBytes(str).Length;
                    break;
                default:
                    byteLength = System.Text.Encoding.GetEncoding(charSetName).GetBytes(str).Length;
                    break;
            }
            return byteLength;
        }

        /// <summary>
        /// 控件输入内容合法性检测
        /// </summary>
        /// <param name="objects">Object后需要加[]，表示是Object类型的一维数组，params后必须是一维数组，使用Control类需要System.Web.UI;命名空间</param>
        /// <returns></returns>
        public static bool MustInputCheckForObject(params Object[] objects)
        {
            bool isCheckPass = true;

            foreach (Object obj in objects)
            {
                switch ((obj.GetType()).Name)
                {
                    case "TextBox":

                        TextBox tbx = (TextBox)obj;
                        if (String.IsNullOrEmpty(tbx.Text) == true)
                            isCheckPass = false;
                        tbx.Text = "tttttttttttttttttttttt";

                        break;
                    case "DropDownList":
                        DropDownList ddl = (DropDownList)obj;
                        if (String.IsNullOrEmpty(ddl.SelectedValue) == true)
                            isCheckPass = false;
                        ddl.Items.Add("aaa");
                        break;
                    case "Label":
                        Label lbl = (Label)obj;
                        if (String.IsNullOrEmpty(lbl.Text) == true)
                            isCheckPass = false;
                        lbl.Text = "llllllllllllllllllll";
                        break;
                }

            }
            return isCheckPass;


        }

        /// <summary>
        /// 将合法的Code39字符串增加一个校验位
        /// </summary>
        /// <param name="strNeedCheckDigit"></param>
        /// <returns></returns>
        public static string Code39Mod43Check(string strNeedCheckDigit)
        {
            Dictionary<string, int> Code39Mod43Dic = new Dictionary<string, int>();
            Code39Mod43Dic.Add("0", 0);
            Code39Mod43Dic.Add("1", 1);
            Code39Mod43Dic.Add("2", 2);
            Code39Mod43Dic.Add("3", 3);
            Code39Mod43Dic.Add("4", 4);
            Code39Mod43Dic.Add("5", 5);
            Code39Mod43Dic.Add("6", 6);
            Code39Mod43Dic.Add("7", 7);
            Code39Mod43Dic.Add("8", 8);
            Code39Mod43Dic.Add("9", 9);
            Code39Mod43Dic.Add("A", 10);
            Code39Mod43Dic.Add("B", 11);
            Code39Mod43Dic.Add("C", 12);
            Code39Mod43Dic.Add("D", 13);
            Code39Mod43Dic.Add("E", 14);
            Code39Mod43Dic.Add("F", 15);
            Code39Mod43Dic.Add("G", 16);
            Code39Mod43Dic.Add("H", 17);
            Code39Mod43Dic.Add("I", 18);
            Code39Mod43Dic.Add("J", 19);
            Code39Mod43Dic.Add("K", 20);
            Code39Mod43Dic.Add("L", 21);
            Code39Mod43Dic.Add("M", 22);
            Code39Mod43Dic.Add("N", 23);
            Code39Mod43Dic.Add("O", 24);
            Code39Mod43Dic.Add("P", 25);
            Code39Mod43Dic.Add("Q", 26);
            Code39Mod43Dic.Add("R", 27);
            Code39Mod43Dic.Add("S", 28);
            Code39Mod43Dic.Add("T", 29);
            Code39Mod43Dic.Add("U", 30);
            Code39Mod43Dic.Add("V", 31);
            Code39Mod43Dic.Add("W", 32);
            Code39Mod43Dic.Add("X", 33);
            Code39Mod43Dic.Add("Y", 34);
            Code39Mod43Dic.Add("Z", 35);
            Code39Mod43Dic.Add("-", 36);
            Code39Mod43Dic.Add(".", 37);
            Code39Mod43Dic.Add(" ", 38);
            Code39Mod43Dic.Add("$", 39);
            Code39Mod43Dic.Add("/", 40);
            Code39Mod43Dic.Add("+", 41);
            Code39Mod43Dic.Add("%", 42);



            strNeedCheckDigit = strNeedCheckDigit.ToUpper();        //将字符串改为大写

            int mappingSum = 0;                                                         //字符串中每个字符映射之和

            for (int i = 0; i < strNeedCheckDigit.Length; i++)
            {
                mappingSum = mappingSum + Code39Mod43Dic[strNeedCheckDigit.Substring(i, 1)];
            }

            int modOfSum = mappingSum % 43;                                 //将映射之和按照43取余
            string checkDigit = string.Empty;



            ////取得字典中Value对应的Key：方法1，Foreach循环
            //foreach (KeyValuePair<string, int> kvp in Code39Mod43Dic)
            //{
            //    if (kvp.Value == modOfSum)
            //    {
            //        checkDigit = kvp.Key.ToString();
            //    }
            //}

            ////取得字典中Value对应的Key：方法2，Foreach循环
            //foreach (string key in Code39Mod43Dic.Keys)
            //{
            //    if (Code39Mod43Dic[key] == modOfSum)
            //    {
            //        checkDigit = key.ToString();
            //    }
            //}


            ////取得字典中Value对应的Key：方法3，Linq取得所有Keys
            //var keys = Code39Mod43Dic.Where(q => q.Value == modOfSum).Select(q => q.Key);         //取得余数对应的字符，作为校验位。


            ////取得字典中Value对应的Key：方法4，Linq取得所有Keys
            //List<string> keyList = (from q in Code39Mod43Dic
            //                        where q.Value == modOfSum
            //                        select q.Key).ToList<string>();


            //取得字典中Value对应的Key：方法5，Linq取得第一个Key
            checkDigit = Code39Mod43Dic.FirstOrDefault(q => q.Value == modOfSum).Key.ToString();



            string checkedStr = "*" + strNeedCheckDigit + checkDigit.ToString() + "*";

            return checkedStr;
        }




        public static int Code39Map(string code39Char)
        {
            switch (code39Char)
            {
                case "0": return 0;
                case "1": return 1;
                case "2": return 2;
                case "3": return 3;
                case "4": return 4;
                case "5": return 5;
                case "6": return 6;
                case "7": return 7;
                case "8": return 8;
                case "9": return 9;
                case "A": return 10;
                case "B": return 11;
                case "C": return 12;
                case "D": return 13;
                case "E": return 14;
                case "F": return 15;
                case "G": return 16;
                case "H": return 17;
                case "I": return 18;
                case "J": return 19;
                case "K": return 20;
                case "L": return 21;
                case "M": return 22;
                case "N": return 23;
                case "O": return 24;
                case "P": return 25;
                case "Q": return 26;
                case "R": return 27;
                case "S": return 28;
                case "T": return 29;
                case "U": return 30;
                case "V": return 31;
                case "W": return 32;
                case "X": return 33;
                case "Y": return 34;
                case "Z": return 35;
                case "-": return 36;
                case ".": return 37;
                case " ": return 38;
                case "$": return 39;
                case "/": return 40;
                case "+": return 41;
                case "%": return 42;
                default: return 43;
            }            
        }

        public static string Code39Map(int code39Int)
        {
            switch (code39Int)
            {
                case 0: return "0";
                case 1: return "1";
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
                case 16: return "G";
                case 17: return "H";
                case 18: return "I";
                case 19: return "J";
                case 20: return "K";
                case 21: return "L";
                case 22: return "M";
                case 23: return "N";
                case 24: return "O";
                case 25: return "P";
                case 26: return "Q";
                case 27: return "R";
                case 28: return "S";
                case 29: return "T";
                case 30: return "U";
                case 31: return "V";
                case 32: return "W";
                case 33: return "X";
                case 34: return "Y";
                case 35: return "Z";
                case 36: return "-";
                case 37: return ".";
                case 38: return " ";
                case 39: return "$";
                case 40: return "/";
                case 41: return "+";
                case 42: return "%";
                default: return "ERROR";
            }
        }

    }
}


