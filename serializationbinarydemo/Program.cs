using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace serializationbinarydemo
{
    public class App
    {
        [STAThread]
        static void Main()
        {
            Serialize();
            Deserialize();
        }

        static void Serialize()
        {

            Hashtable addresses = new Hashtable();
            addresses.Add("Mukesh Ambani", "Altamount Road, Cumballa Hill, Mumbai");
            addresses.Add("Ratan Tata", " Bombay House, Homi Mody Street, Mumbai ");
            addresses.Add("Lakshmi Mittal", "Sadulpur, Rajasthan");


            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, addresses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        static void Deserialize()
        {

            Hashtable addresses = null;

            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                addresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            foreach (DictionaryEntry de in addresses)
            {
                Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
            }
        }


    }
}

