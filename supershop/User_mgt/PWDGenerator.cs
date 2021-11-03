
using System;
using System.Text;
using System.Collections;

namespace supershop.User_mgt
{
    class PWDGenerator
    {      
        public static string GeneratePWD()
        {
            int passwordLength = 10;
            int quantity = 1;
            ArrayList arrCharPool = new ArrayList();
            Random rndNum = new Random();
            arrCharPool.Clear();
            string password = "";

           
            //Lower Case 
            for (int i = 97; i < 123; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }
             //Number
            for (int i = 48; i < 58; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }

             //Upper Case 
            for (int i = 65; i < 91; i++)
            {
                arrCharPool.Add(Convert.ToChar(i).ToString());
            }
           


            for (int x = 0; x < quantity; x++)
            {
                //Iterate through the number of characters required in the password
                for (int i = 0; i < passwordLength; i++)
                {
                    password += arrCharPool[rndNum.Next(arrCharPool.Count)].ToString();
                }
            }

            return password;
        
        }
    }
    
}
