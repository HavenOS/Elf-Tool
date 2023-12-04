using System.IO;
using System.Runtime.InteropServices;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Elf_Tool
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        byte[] byteArray;
        public Form1()
        {
            InitializeComponent();
        }
        public void run()
        {
            Console.Write("Tool by: " + Application.CompanyName);
            //call elf info class
            Elf elfinfo = new Elf();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                    sbyte[] comparisonByteArray = { 127, 69, 76, 70, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int i;
                    for (i = 0; i <= ofd.FileName.Length; i++)
                    {
                        br.BaseStream.Position = i;
                        byteArray = br.ReadBytes(16);
                        elfinfo.e_ident = new sbyte[byteArray.Length];
                        Buffer.BlockCopy(byteArray, 0, elfinfo.e_ident, 0, byteArray.Length);
                        elfinfo.e_type = BitConverter.ToUInt16(br.ReadBytes(2));
                        elfinfo.e_machine = BitConverter.ToUInt16(br.ReadBytes(2));
                        elfinfo.e_version = BitConverter.ToUInt32(br.ReadBytes(4));
                        // check if is a elf file
                        if (!elfinfo.e_ident.SequenceEqual(comparisonByteArray))
                        {
                            MessageBox.Show("this is not a elf file");
                            break;
                        }
                        // check if console is not null and then clear
                        if (Console.Read != null)
                        {
                            Console.Clear();
                        }
                        Console.Write("e_ident: ");
                        // parse e.ident bytes to console
                        foreach (sbyte b in elfinfo.e_ident)
                        {
                            Console.Write(b + " ");
                        }
                        //write elf info on console.
                        Console.WriteLine("\n" + "e_type: " + elfinfo.e_type + "\n" + "e_machine: " + elfinfo.e_machine + "\n" + "e_version : " + elfinfo.e_version);
                        break;
                        br.Close();

                    }
                }
                catch (Exception e)
                {
                    //  Block of code to handle errors
                }


            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //run console
            AllocConsole();
        }

        private void loadElfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            write();
        }
        public void write()
        {
            GeometryInfo[] array = new GeometryInfo[]
        {
            new GeometryInfo(1978, 673, 1976, 0)
        };
            string filePath = "D://object.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("// m228__20801.o");
                writer.WriteLine($"Array[{array.Length}] of GeometryInfo @0 {{");

                for (int i = 0; i < array.Length; i++)
                {
                    var geometryInfo = array[i];
                    writer.WriteLine($"    GeometryInfo GeometryInfo.{i}[0] {{");
                    writer.WriteLine($"        NumIndices: {geometryInfo.NumIndices}");
                    writer.WriteLine($"        NumVertices: {geometryInfo.NumVertices}");
                    writer.WriteLine($"        NumPrimitives: {geometryInfo.NumPrimitives}");
                    writer.WriteLine($"        unknown1: {geometryInfo.Unknown1}");
                    writer.WriteLine("    }");
                }

                writer.WriteLine("}");
            }

            Console.WriteLine($"C# code written to {filePath}");
        }
    }
}
