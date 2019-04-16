using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ARRRRRRRRRR
{
    class Program
    {

        public class Director
        {
            Builder builder;

            public Director(Builder builder)
            {
                this.builder = builder;
            }


            public void Construct(string path)
            {
                builder.Create(path);
                builder.AddHeader();
                builder.AddBody();
                builder.Close();
            }
        }

        public abstract class Builder
        {
            public string Path;
            public Array Ar { get; set; }
            public Builder(Array ar)
            {
                Ar = ar;
            }
            public virtual void Create(string path)
            {
                Path = path;
            }
            public abstract void AddHeader();
            public abstract void AddBody();
            public abstract void Close();
        }

        public class Array
        {

            public int Rows { get; set; } = 5;
            public int Cols { get; set; } = 5;
            public int[,] myMatrix { get; set; }

            public Array()
            {

                this.myMatrix = myMatrix;
            }
            public Array(int rows, int cols)
            {
                Rows = rows;
                Cols = cols;
            }
            public Array(int[,] ar)
            {
                myMatrix = ar;
            }

        }

        public class TxtBuilder : Builder
        {
            //private StreamWriter sw ;
            public TxtBuilder(Array ar) : base(ar) { }

            public override void AddBody()
            {

                using (TextWriter sw = new StreamWriter("test4.txt"))
                {
                    int[,] myMatrix = new int[Ar.Rows, Ar.Cols];
                    int i = Ar.Rows;
                    int j = Ar.Cols;
                    for (i = 0; i < Ar.Rows; i++)
                        for (j = 0; j < Ar.Cols; j++)
                            myMatrix[i, j] = i * j;

                    for (i = 0; i < Ar.Rows; i++)
                    {
                        for (j = 0; j < Ar.Cols; j++)
                        {
                            sw.Write(myMatrix[i, j] + "\t");

                            //Console.WriteLine();
                        }
                        sw.WriteLine();
                        //Console.ReadLine();
                    }

                }

            }
            public override void AddHeader()
            {

            }

            public override void Create(string path)
            {


            }


            public override void Close()
            {
                //sw.Dispose();
            }

        }

        public class XMLBuilder : Builder
        {
            public XMLBuilder(Array ar) : base(ar)
            {
            }

            public override void AddBody()
            {

                int[,] myMatrix = new int[Ar.Rows, Ar.Cols];
                int i = Ar.Rows;
                int j = Ar.Cols;
                for (i = 0; i < Ar.Rows; i++)
                    for (j = 0; j < Ar.Cols; j++)
                        myMatrix[i, j] = i * j;
                XDocument doc = new XDocument();
                var xArray = new XElement("Array");
                doc.Add(xArray);

                for (i = 0; i < Ar.Rows; i++)
                {
                    XElement row = new XElement("Row");


                    for (j = 0; j < Ar.Cols; j++)
                    {
                        row.Add(new XElement("Int", myMatrix[i, j]));
                        xArray.Add(row);

                        //Console.WriteLine();
                    }
                    doc.Save("test.xml");
                    //Console.ReadLine();
                }

            }

            public override void AddHeader()
            {

            }

            public override void Close()
            {

            }
        }

        public class HtmlBuilder : Builder
        {
            private StreamWriter sw;
            public HtmlBuilder(Array ar) : base(ar)
            {
            }

            public override void Create(string path)
            {
                base.Create(path);
                StreamWriter sw = new StreamWriter(path);
                this.sw = sw;
            }

            public override void AddBody()
            {
                using (StreamWriter sw = new StreamWriter("test3.html"))
                {
                    int[,] myMatrix = new int[Ar.Rows, Ar.Cols];
                    int i = Ar.Rows;
                    int j = Ar.Cols;
                    for (i = 0; i < Ar.Rows; i++)
                        for (j = 0; j < Ar.Cols; j++)
                            myMatrix[i, j] = i * j;
                    sw.WriteLine("<table>");
                    for (i = 0; i < Ar.Rows; i++)
                    {
                        sw.WriteLine("<tr>");
                        for (j = 0; j < Ar.Cols; j++)
                        {
                            sw.Write("<td>");
                            sw.Write(myMatrix[i, j]);
                            sw.WriteLine("<td>");
                        }
                        sw.WriteLine("</tr>");
                    }
                }
            }

            public override void AddHeader()
            {
               
                    sw.WriteLine("<!DOCTYPE>");
                    sw.WriteLine("<htm>");
                
            }

            public override void Close()
            {

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter hight");
            int Rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Weight");
            int Cols = Convert.ToInt32(Console.ReadLine());
            Array ar = new Array(Rows, Cols);
            Builder builder;

            int choise = 3;
            switch (choise)
            {
                case 1:
                    //Console.WriteLine("Enter hight");
                    //int Rows = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter Weight");
                    //int Cols = Convert.ToInt32(Console.ReadLine());
                    //Array ar = new Array(Rows, Cols);
                    //Builder builder ;
                    builder = new TxtBuilder(ar);
                    break;
                //Director dir = new Director(builder);
                //dir.Construct("test.txt");

                //Console.ReadLine();



                case 2:
                    //Console.WriteLine("Enter hight");
                    //int Rows = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter Weight");
                    //int Cols = Convert.ToInt32(Console.ReadLine());

                    //Array ar = new Array(Rows, Cols);
                    //Builder builder;
                    builder = new XMLBuilder(ar);
                    break;
                //Director dir = new Director(builder);
                //dir.Construct("test.txt");

                //Console.ReadLine();



                case 3:
                    //Console.WriteLine("Enter hight");
                    //int Rows = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter Weight");
                    //int Cols = Convert.ToInt32(Console.ReadLine());

                    //Array ar = new Array(Rows, Cols);
                    //Builder builder;
                    builder = new HtmlBuilder(ar);
                    break;
                //Director dir = new Director(builder);
                //dir.Construct("test.html");

                //Console.ReadLine();
                default: throw new NullReferenceException("..............");
            }
            Director dir = new Director(builder);
            dir.Construct("test3");
        }

        }
    }
