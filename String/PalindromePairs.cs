using CodingAlgorithms.Contracts;
using CodingAlgorithms.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Problems
{
    public class PalindromePairs : IQuestion
    {
        public static IList<IList<int>> Find(string[] words)
        {

            Dictionary<int, string> dic = new Dictionary<int, string>();
            int i = 0;
            StringBuilder sb = new StringBuilder();

            IList<IList<int>> intFinalList = new List<IList<int>>();
            bool IsAddLeft = false;
            bool IsAddRight = false;

            foreach (var s in words)
            {
                dic.Add(i++, s);
            }

            for (i = 0; i < dic.Count; i++)
            {
                for (int j = i; j < dic.Count; j++)
                {
                    IList<int> intList = new List<int>();
                    if (dic[i] != dic[j])
                    {
                        sb.Append(dic[i] + dic[j]);

                        if (Palindrome.IsPalindrome(sb.ToString()))
                        {
                            IsAddLeft = true;
                        }
                        sb.Clear();
                        sb.Append(dic[j] + dic[i]);
                        if (Palindrome.IsPalindrome(sb.ToString()))
                        {
                            IsAddRight = true;

                        }
                    }
                    if (IsAddLeft)
                    {
                        var list = new List<int>() { i, j };
                        intFinalList.Add(list);

                    }
                    if (IsAddRight)
                    {
                        var list = new List<int>() { j, i };
                        intFinalList.Add(list);
                    }
                    //intList.Clear();
                    sb.Clear();
                    IsAddLeft = false;
                    IsAddRight = false;
                }

            }
            return intFinalList;


        }


        public void Run()
        {
            //Given a list of unique words, find all pairs of distinct indices(i, j) in the given list, so that the concatenation of the two words, i.e.words[i] + words[j] is a palindrome.

            //Example 1:
            //Given words = ["bat", "tab", "cat"]
            //Return[[0, 1], [1, 0]]
            //The palindromes are["battab", "tabbat"]
            //Example 2:
            //Given words = ["abcd", "dcba", "lls", "s", "sssll"]
            //Return[[0, 1], [1, 0], [3, 2], [2, 4]]
            //The palindromes are["dcbaabcd", "abcddcba", "slls", "llssssll"]

              string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };

            //string[] words = new string[] { "djejb", "hciii", "ea", "jggiaieifhigfhhbd", "iacgb", "h", "gbjahbedfhdfcjjgce", "dfcefe", "egd", "hbab", "ejbddgiificideiijje", "giicgajijdcihef", "fehghgjccfggahgjj", "gdjjbfjje", "dacff", "idhabh", "ieaciahjcbebdejf", "biigjihbdfjhcfffie", "dgfahaa", "jjdjghfefbbbhcadid", "cbjcjiebdfe", "dedbgefgjhaffehagg", "cghdidchgffd", "bahcggebbg", "ebaijijddbbgcacjj", "idjb", "aejhhhjgceccbigaabd", "bgh", "gedffgg", "ebhjhdahfbi", "dibd", "gjchdbfchafei", "ahdfjiiabiffabhca", "ad", "cijhcca", "cdccdb", "ciiijgafadgiecgb", "eeej", "ebhbcegh", "ceg", "cjchfeacebeheecdbg", "fbd", "ihd", "bichfbdcehidf", "djcegdjdgeda", "agdhggcfhebfggcbca", "afj", "aicbjaj", "cgdgg", "igeajdfbh", "gggfehefbbdigijfcid", "ecciibdgcadjgbfgjbfj", "aeedhbfeed", "biccehabcdfdabc", "jdjejchcifgif", "ebgdachbjhja", "jaacdf", "fgicdcb", "ggecg", "hbeifd", "dbbjdhech", "fede", "dfafbhijjfgdagbfcc", "jbe", "dhadiehefgh", "iadhbejdjjiegebhfg", "egddjjbiaigdgab", "acjfajj", "gdjbjbcdcgiabbfgcji", "e", "ijfe", "a", "cdgadcjahddib", "jaifjhddhdddaedb", "j", "feiafchicb", "djji", "fgeabh", "cbejbehb", "jaj", "cehaffgjjfdjb", "jcfdaabahajaejg", "jhaicda", "gcjgheahaicgcageeja", "chej", "cjejfcfgbahieiibjhd", "hgbgjhf", "cd", "dcffjcdihgbdfjjfdf", "b", "ejgfhccabjjaiajag", "hfhihg", "iddhhbiddhjdjajgf", "fhijjijh", "egfhgbgfi", "jfcbbag", "hfa", "fdgbfjdghadigghjgghb", "ejha", "ijbdc", "ebhdidifdfefcegjjahb", "dgiejcgfgfjgdbd", "bhhafabcj", "gijgjjgfhifjihidha", "bjdieie", "hfbbafgejidded", "he", "fdeghfchcafbaf", "diihcdgiidiejdiabee", "iagbb", "fbbdgh", "bccbgegbabghhggiij", "bc", "daiijbjbfjgajde", "hgfjaabggeaeh", "dc", "eedficedihfc", "dbibgchaddidceg", "fagigfefbbccgdbjfcgi", "egjiifachdhabadcchi", "iciiiadfaahbej", "jgbbfd", "ibcbicgi", "gffcdecciffefibebfg", "idbfcifbgifiaca", "dfg", "cb", "bgbb", "fchdjj", "ffbfffacbg", "bagh", "ccdc", "ieadegicagbf", "icdjjgic", "eihdeeaeeefbjgeaefi", "hfbj", "fajcbffedjeebfahjb", "bfa", "hffeeidajgcf", "ahfbjafib", "aiggcafjdhi", "fdfebcehjcdefia", "ichgbdfghjghab", "bgbhgjgfhbb", "bdaehgabdfcihibfa", "caahaecggi", "geadiaiibhjgjcb", "gefjeicbhgbbcafg", "hdfgbcijaef", "chigiefahceeebifbijc", "jbcccfgihddcjg", "gcbcjdfbhegfjfba", "jagddjjhji", "cg", "bhecffha", "jbabcdaghe", "ggjcjdfbgdijdagieg", "hjedhedibbjjbbfge", "bhgajjdbja", "hcjeihch", "bcgjaicfc", "ceabfj", "fdh", "aijbifajh", "ieicdhja", "dedbaifddhideea", "ahaci", "hj", "cbhcagg", "fbbfddi", "ehabiieifcbhagda", "iiief", "gbdiabgbabaccgef", "afajjcjgfdjgjghjei", "cbjiaecjgghc", "agccjgcahcicacajia", "fbjfebgffebdafhh", "dcchgbaid", "ddaadiedgcagie", "ebjbb", "gbbbidhgfjfcbccia", "jjfaijbej", "fhee", "ah", "bghbgjfbde", "i", "ijgbjccjcegigegjfdie", "iafd", "fbfacfhididac", "hhhcghhd", "ihccfiaefhffg", "jjcf", "heidahegjg", "ihfcjgghchgdjc", "icaiifjihjfhgjjej", "bdfdjdegdee", "icgei", "eadagadcbhehadijahb", "c", "edcaee", "gbjca", "gcjajhe", "fdaacegbcafdai", "ceihdhceehdidada", "djcjajgbgbihhi", "eebdcfdg", "fiijdjcb", "efjfgjcaf", "cfddbaagagdj", "hegfd", "bfchgee", "aajffhd", "gbgjbdbibjhfeiajffd", "cgbedhhcjjab", "iegbhaaecabcciicjbf", "hiddhgbdifeg", "figafefdijfheh", "cjgb", "ifjcdfdjddaeh", "aiccbdfbiighcfbj", "jb", "fhgf", "dhcgffeaijj", "ajc", "gdcfffjecefhgcja", "aih", "dehchjeaif", "egcfeaiicebhah", "cbdhhaehaef", "ecceebcddeehh", "iiafbdj", "ahbegi", "bibeihgehjjjjajaeeci", "ehjccdajjdaediiijcfi", "abieccdeihfiddfjde", "jihhj", "hbajbddaabifgcdb", "ffbdfgcdgdfcdi", "g", "aiga", "eaceeeeededee", "bhhdiaebdbhba", "igdjeicehcce", "ihhbdjhidcfgf", "fcc", "bejghijjecfccd", "efbgbi", "ffhbcffbegagjdgj", "de", "giaigagfbj", "jhiicdcjjb", "hhbgeieacfgdgbgd", "hbgaibjic", "dagdciaddgdahgab", "dcciigdcaih", "becdagbgcfgfjfggbbf", "gbd", "ijhbgdbjgdcjig", "edddfgaifbbea", "iaidbeeddaecheg", "haheicahbcdjfbahjj", "cjcaeaaabjjdghh", "jbaaefajacfb", "jcbcaahe", "edeideaichafeabcijf", "ggbjbhhaacijfji", "hbehhhfcgagaiehe", "cbjcadaggeedacchd", "cdfcegb", "ihiiicahdh", "hcehijaea", "cedfjgbeafajef", "ahhdfgjbh", "bgjbdhjicecahccdg", "hibehd", "feefabggde", "ahdcic", "bchdbhdgjffgdiihfgdi", "fjbbejijfecbdjehab", "aeacjfcechi", "hfcechceehdfjb", "iifhhif", "edghfgajae", "fhaieieee", "ijcaj", "jfgbhdgbie", "caaaihg", "cjfbjcigbcejdbcha", "igjdadcjgcibib", "hgeaffiehjeajeichf", "bhhcadjiebfibchh", "fahhi", "bfefhjaa", "hgifjbajgeii", "giebbjbgbdagea", "ejigdbjddeec", "jbacea", "hhfihb", "jhaaj", "adeddbdagjacaej", "ged", "ecfjjdaaahbggedg", "cfcihcbdgjiafa", "eigjbahbgahgejihfe", "bjgggcjha", "cfafbibg", "hjjhiihhh", "ddg", "icjidiic", "f", "febiajgg", "geihfigdchidfgfgdjc", "hgfac", "ehfbg", "aciabbedgacgabecahe", "figdiafagffaidhgc", "fjdcadhiaede", "ejgaeddgdgidfjighaje", "idji", "hejceiccfee", "hifif", "debhdiee", "fbjh", "jhb", "gihceeaahehfggahb", "jbdeabg", "iaijjcgjh", "efibheehhgjggfj", "gbcjagfifegdjf", "fijjgjigdcacecgddhhd", "gbicjcihdbid", "jjfifcf", "idhhia", "eiccfhajeb", "bbhgbfiddj", "jejeacaghjbgdcihcec", "bgciagggdf", "giifiebcchfhedaggjj", "hdhiajehagjgdahhahib", "adbcc", "edibeic", "hi", "febiagcihhicgefjd", "ghdhbcheecc", "bigacagci", "icbbgcd", "bbhccjeabjh", "hejgdihgbfbficjbafg", "ijbghfgfgjjej", "ffeiggafaggcaaihehia", "ghaeicjidfciifcha", "eeaiijbcb", "gbbdijafcca", "fceb", "cbb", "jicjeaafbehgi", "aea", "eejcgfcbijjh", "abbahgbfeecge", "ffgbagdcjjjifee", "caacfe", "gabbjihbhiia", "ejcjjjbbdabehcidfcjj", "cbgfjgeiihje", "d", "bifg", "efajiebahbdai", "bddcdcfghgi", "cejdccfa", "iaaeabfigagbabihihda" };

            var result = Find(words);
            foreach (var res in result)
            {
                    Console.WriteLine("[" + res.ElementAt(0) + "," + res.ElementAt(1)+ "]");
              
            }
            Console.ReadLine();
        }
    }
}
