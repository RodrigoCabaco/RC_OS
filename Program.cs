using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.Design;

namespace TerminalBasedOs_Try
{
    class Program
    {
        static void Main(string[] args)
        {

            //initialization
            

            string ReadLineStr;
            int ReadLineInt = 0;
            string[] itemIndexes = { "Main", "Index" };
            string[] Items = { "Main", "Index" };
            Console.WriteLine(">> Starting <<");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(">> Started <<");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            string logReader;
            string NewItemName;
            int MainItemIndex;
            string TypeOfNewItem;
            int indexNumber;
            string[] ModifyItemTypes = { "Name" }; 
            List<string> SubItems2List = new List<string>();
            SubItems2List.Add("Empty");
            List<string> SubItems1List = new List<string>();
            SubItems1List.Add("Empty");
            List<string> ItemTypes1List = new List<string>();
            ItemTypes1List.Add("None");
            List<string> ItemTypes2List = new List<string>();
            ItemTypes2List.Add("None");
            string[] ItemTypes = { "itm.txt", "itm.Indexer" };
            StreamWriter SubItems1Log;
            StreamWriter SubItems2Log;
            StreamWriter ItemTypes1Log;
            StreamWriter ItemTypes2Log;
            StreamWriter SubItems1ContentList;
            StreamWriter SubItems2ContentList;
            StreamWriter ItemNameLog;
            
        

            //content
            List<string> SubItems1Content = new List<string>();
            List<string> SubItems2Content = new List<string>();

            //remember this
            /*  Stream fileReader = new FileStream("SubItems1Log.txt", FileMode.Append);
                      SubItems1Log = new StreamWriter(fileReader, Encoding.UTF8, default, false);*/





            for (int i = 0; i < 5; i--)
            {

              
                Console.Write(">>");
              
                
                ReadLineStr = Console.ReadLine();
                if(ReadLineStr.ToString() == null)
                {
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                }
                if (ReadLineStr == "lsItems")
                {
                    ShowItems(false);                  
                }

                if(ReadLineStr == "lsItems --content")
                {
                    int indexmp = 0;
                    int MainIndex;
                    int InIndex;
                    foreach (var item in Items)
                    {
                        Console.WriteLine(indexmp + " - " + item);
                        indexmp++;
                    }
                    Console.WriteLine(">>Enter the Index of the Main Item");
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                    MainIndex = ReadLineInt;
                    indexNumber = MainIndex;
                    ShowItem();
                    Console.WriteLine(">>Enter the Index of the In Item");
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                    InIndex = ReadLineInt;
                    ModifyContent(MainIndex, InIndex);
                    
                }
                if (ReadLineStr == "lsItems --content-see")
                {
                    int indexAdd = 0;
                    int MainIndex;
                    int InIndex;
                    foreach (var item in Items)
                    {
                        Console.WriteLine(indexAdd + " - " + item);
                        indexAdd++;
                    }
                    Console.WriteLine(">>Enter the Main Item Index");
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                    MainIndex = ReadLineInt;
                    if (MainIndex == 0)
                    {
                        indexNumber = 0;
                        ShowItem();
                        Console.WriteLine(">>Enter the In Item Index");
                        ReadLineInt = Convert.ToInt32(Console.ReadLine());
                        InIndex = ReadLineInt;
                        Console.Clear();
                        Console.WriteLine(SubItems1Content[InIndex]);
                    } else if (MainIndex == 1)
                    {
                        indexNumber = 1;
                        ShowItem();
                        Console.WriteLine(">>Enter the In Item Index");
                        ReadLineInt = Convert.ToInt32(Console.ReadLine());
                        InIndex = ReadLineInt;
                        Console.Clear();
                        Console.WriteLine(SubItems2Content[InIndex]);
                    }
                    
                    

                }


                //save, write and close the log stream, when called back opens again;
                if (ReadLineStr == "Save" || ReadLineStr == "saveLog" || ReadLineStr == "SaveLog" || ReadLineStr == "save")
                {
                   

                    if (!File.Exists("SubItems1Log.txt"))
                    {
                        SubItems1Log = File.CreateText("SubItems1Log.txt");
                    }
                    else
                    {
                        SubItems1Log = File.CreateText("SubItems1Log.txt");
                    }

                    if (!File.Exists("SubItems2Log.txt"))
                    {
                        SubItems2Log = File.CreateText("SubItems2Log.txt");
                    }
                    else
                    {
                        SubItems2Log = File.CreateText("SubItems2Log.txt");

                    }

                    if (!File.Exists("ItemTypes1Log.txt"))
                    {
                        ItemTypes1Log = File.CreateText("ItemTypes1Log.txt");
                    }
                    else
                    {
                        ItemTypes1Log = File.CreateText("ItemTypes1Log.txt");
                    }

                    if (!File.Exists("ItemTypes2Log.txt"))
                    {
                        ItemTypes2Log = File.CreateText("ItemTypes2Log.txt");
                    }
                    else
                    {
                        ItemTypes2Log = File.CreateText("ItemTypes2Log.txt");
                    }
                   
                    
                    if (!File.Exists("ItemsNameLog.txt"))
                    {
                        ItemNameLog = File.CreateText("ItemNameLog.txt");
                    }
                    else
                    {
                        ItemNameLog = File.CreateText("ItemNameLog.txt");
                    }

                    foreach (var item in SubItems1List)
                    {       
                        SubItems1Log.WriteLine(item);
                    }
                    foreach (var item in SubItems2List)
                    {
                        SubItems2Log.WriteLine(item);
                    }


                    foreach (var item in ItemTypes1List)
                    {
                        ItemTypes1Log.WriteLine(item);
                    }
                    foreach (var item in ItemTypes2List)
                    {
                        ItemTypes2Log.WriteLine(item);
                    }

                    foreach (var item in Items)
                    {
                        ItemNameLog.WriteLine(item);
                    }

                    SubItems1Log.Close();
                    SubItems2Log.Close();
                    ItemTypes1Log.Close();
                    ItemTypes2Log.Close();
                    ItemNameLog.Close();
                }

                //load System
                
                if(ReadLineStr == "load")
                {

                    
                    

                    int counterSubItems1 = 0;
                    int counterSubItems2 = 0;
                    int counterItemTypes1 = 0;
                    int counterItemTypes2 = 0;
                    int counterContent1 = 0;
                    int counterContent2 = 0;
                    int counterItemLogs = 0;
                    StreamReader fileReader;
                    string lineReader;
                    fileReader = new StreamReader("SubItems1Log.txt");

                    while((lineReader = fileReader.ReadLine()) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        counterSubItems1++;

                        if (counterSubItems1 <= 1)
                        {
                            SubItems1List[0] = lineReader;
                        }
                        else
                        {
                            SubItems1List.Add(lineReader);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Subitems (Main)...");
                    }
                    fileReader = new StreamReader("SubItems2Log.txt");

                    while((lineReader = fileReader.ReadLine()) != null)
                    {
                        counterSubItems2++;
                        if(counterSubItems2 <= 1)
                        {
                            SubItems2List[0] = lineReader;
                        }
                        else
                        {
                            SubItems2List.Add(lineReader);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Subitems (Index)...");
                    }

                    fileReader = new StreamReader("ItemTypes1Log.txt");

                    while((lineReader = fileReader.ReadLine()) != null)
                    {
                        counterItemTypes1++;
                        if (counterItemTypes1 <= 1)
                        {
                            ItemTypes1List[0] = lineReader;
                        }
                        else
                        {
                            ItemTypes1List.Add(lineReader);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Item Types (Main)...");

                    }
                    fileReader = new StreamReader("ItemTypes2Log.txt");

                    while((lineReader = fileReader.ReadLine()) != null)
                    {
                        counterItemTypes2++;
                        if (counterItemTypes1 <= 1)
                        {
                            ItemTypes2List[0] = lineReader;
                        }
                        else
                        {
                            ItemTypes2List.Add(lineReader);
                        }
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Item Types (Index)..." );
                    }
                    fileReader = new StreamReader("SubItems1ContentLog.txt");
                    List<string> SubItems1Loader = new List<string>();
                    while ((lineReader = fileReader.ReadLine()) != "endOf" )
                    {
                        SubItems1Loader.Add(lineReader);


                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Content (Main)...");
                    }

                    counterContent1++;
                    SubItems1Content.Add(String.Join("\n", SubItems1Loader.ToArray()));
                    Console.WriteLine("- Loaded Content (Main)");


                    fileReader = new StreamReader("SubItems2ContentLog.txt");
                    List<string> SubItems2Loader = new List<string>();

                    while ((lineReader = fileReader.ReadLine()) != "endOf")
                    {
                        SubItems2Loader.Add(lineReader);
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine("- Loading Content (Index)...");
                    }
                    counterContent2++;
                    SubItems2Content.Add(String.Join("\n", SubItems2Loader.ToArray()));
                    Console.WriteLine("- Loaded Content (Index)");

                    fileReader = new StreamReader("ItemNameLog.txt");
                    while((lineReader = fileReader.ReadLine()) != null)
                    {
                        counterItemLogs++;
                        if(counterItemLogs <= 1)
                        {
                            Items[0] = lineReader;
                        }
                        else
                        {
                            Items[1] = lineReader;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(">> " + "" + "Loading Completed Successfully!");
                    Console.WriteLine("-----------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }









                if (ReadLineStr == "lsItems --modify")
                {
                    ShowItems(true);
                }

                if (ReadLineStr == "exit")
                {
                    
                    Environment.Exit(1);
                }


                if (ReadLineStr == "lsItems --modify-in")
                {
                    int MainIndex;
                    Console.WriteLine(">>Enter the Main Index of the item");
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                    MainIndex = ReadLineInt;
                    

                    if (MainIndex == 0)
                    {
                        string NewItemModifier;
                        int IndexOfInItemModified;
                        string MethodName;
                        indexNumber = 0;
                        ShowItem();
                        Console.WriteLine(">>Enter the index of the InItem to modify");
                        ReadLineInt = Convert.ToInt32(Console.ReadLine());
                        IndexOfInItemModified = ReadLineInt;
                        Console.WriteLine(">>Enter the Method to Apply");
                        foreach (var item in ModifyItemTypes)
                        {
                            Console.WriteLine(" - " + item);
                        }
                        ReadLineStr = Console.ReadLine();
                        
                        MethodName = ReadLineStr; 

                        if (MethodName == "name" || MethodName == "Name")
                        {
                            Console.WriteLine("Chose a new name for the In Item");
                            ReadLineStr = Console.ReadLine();
                            NewItemModifier = ReadLineStr;
                            SubItems1List[IndexOfInItemModified] = NewItemModifier + "." + ItemTypes1List[IndexOfInItemModified];
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(">>Item name modified Successfully");
                            Console.ForegroundColor = ConsoleColor.White;



                        }
                    }



                    if (MainIndex == 1)
                    {
                        string NewItemModifier;
                        int IndexOfInItemModified;
                        string MethodName;
                        indexNumber = 1;
                        ShowItem();
                        Console.WriteLine(">>Enter the index of the InItem to modify");
                        ReadLineInt = Convert.ToInt32(Console.ReadLine());
                        IndexOfInItemModified = ReadLineInt;
                        Console.WriteLine(">>Enter the Method to Apply");
                        foreach (var item in ModifyItemTypes)
                        {
                            Console.WriteLine(" - " + item);
                        }
                        ReadLineStr = Console.ReadLine();
                        MethodName = ReadLineStr;

                        if (MethodName == "name" || MethodName == "Name")
                        {
                            Console.WriteLine("Chose a new name for the In Item");
                            ReadLineStr = Console.ReadLine();
                            NewItemModifier = ReadLineStr;
                            SubItems2List[IndexOfInItemModified] = NewItemModifier + "." + ItemTypes2List[IndexOfInItemModified];
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(">>Item name modified Successfully");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                }





                if (ReadLineStr == "createItem" || ReadLineStr == "lsItems --create")
                {
                    Console.WriteLine(">>Enter the Index of the Main item");
                    ReadLineInt = Convert.ToInt32(Console.ReadLine());
                    MainItemIndex = ReadLineInt;
                    Console.WriteLine(">>Enter the Name of the item");
                    ReadLineStr = Console.ReadLine();
                    NewItemName = ReadLineStr;
                    Console.WriteLine(">>Enter the Item type (ex: itm.txt)");
                    
                        ReadLineStr = Console.ReadLine();
                        TypeOfNewItem = ReadLineStr;
                    if (ItemTypes.Contains(TypeOfNewItem))
                        {
                            MakeSubItem(MainItemIndex, NewItemName, TypeOfNewItem);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(">>Item Created Successfully!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                        else
                        {
                            Console.WriteLine(">>Enter a valid Item type");
                            foreach (var item in ItemTypes )
                            {
                                Console.WriteLine(" - " + item);
                            }
                        }



                }
                if (ReadLineStr == "clrAll")
                {
                    Console.Clear();

                }
                if (ReadLineStr == "lsItems --in")
                {
                    Console.WriteLine(">>Index (Int):");

                    indexNumber = Convert.ToInt32(Console.ReadLine());
                    ShowItem();
                    Console.Write(">> ");
                }




            }

            //Methods

            void ShowItems(bool isModify)
            {

                int IndexOfItem = 0;
                if (isModify == false)
                {

                    foreach (var item in Items)
                    {
                        Console.WriteLine(IndexOfItem++ + " - " + item);
                    }

                    ReadLineStr = Console.ReadLine();


                    
                    if (ReadLineStr == "lsIn")
                    {
                        Console.WriteLine(">>Index (Int):");

                        indexNumber = Convert.ToInt32(Console.ReadLine());
                        ShowItem();

                    }
                }




                if (ReadLineStr == "modifyitem" || isModify == true)
                {
                    Console.WriteLine(">>Choose the Modification Method you want to apply");

                    foreach (var item in ModifyItemTypes)
                    {
                        Console.WriteLine("->" + item);
                    }
                    ReadLineStr = Console.ReadLine();
                    if (ReadLineStr == "Name")
                    {
                        IndexOfItem = 0;
                        foreach (var item in Items)
                        {
                            Console.WriteLine(IndexOfItem++ + " - " + item);

                        }
                        Console.WriteLine(">>Choose the Item to apply the Method (Item Index: Int):");
                        indexNumber = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(">>Choose a new Name for the Item");
                        ReadLineStr = Console.ReadLine();
                        Items[ReadLineInt] = ReadLineStr.ToString();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(">>Item name modified Successfully!");
                        Console.ForegroundColor = ConsoleColor.White;
                        isModify = false;
                    }
                }
            }
            void ShowItem()
            {


                Console.WriteLine(itemIndexes[indexNumber]);
                 
                if(indexNumber == 0)
                {
                    int IndexOfInItem = 0;

                    Console.WriteLine(itemIndexes[indexNumber] + " " + "Items:");
                    foreach (var item in SubItems1List)
                    {
                        Console.WriteLine(IndexOfInItem++ +" - " + item);
                    }
                }else if (indexNumber == 1)
                {
                    int IndexOfInItem = 0;

                    Console.WriteLine(itemIndexes[indexNumber] + " " + "Items:");
                    foreach (var item in SubItems2List)
                    {
                        Console.WriteLine(IndexOfInItem++ + " - "  +item);
                    }
                }


            }





            void MakeSubItem(int IndexOfMainItem, string NameOfItem, string TypeOfItem)
            {
             
                int LengthOf1;
                int LengthOf2;
                int TypeLength1;
                int TypeLength2;

               
           
                if (IndexOfMainItem == 0)
                {
                    if (SubItems1List[0] == "Empty")
                    {
                        ItemTypes1List = new List<string> { TypeOfItem };
                        SubItems1List = new List<string> { NameOfItem + "." + ItemTypes1List[0] };


                    }
                    else
                    {
                        ItemTypes1List.Add(TypeOfItem);
                        SubItems1List.Add(NameOfItem + "." + TypeOfItem);
                    }
                }
                if (IndexOfMainItem == 1)
                {
                    if (SubItems2List[0] == "Empty")
                    {
                        ItemTypes2List = new List<string> { TypeOfItem };
                        SubItems2List = new List<string> { NameOfItem + "." + ItemTypes2List[0] };
                        SubItems2Content.Add("Nothing");
                    }
                    else
                    {
                        ItemTypes2List.Add(TypeOfItem);
                        SubItems2List.Add(NameOfItem + "." + TypeOfItem);
                        SubItems2Content.Add("Nothing");
                    }
                }
                
            }

            void ModifyContent(int MainIndex, int IndexInItem)
            {
                Console.Clear();
                List<string> ModifiedContent = new List<string>();
                Console.WriteLine(">> Edit/Create the Content by Clicking Enter << ");
                string Joiner = "none";
                
               

             
                if (MainIndex == 0)
                {
                    if(SubItems1Content[IndexInItem] != null)
                    {
                        Joiner = "none";
                        ModifiedContent.Clear();
                        Console.Write(SubItems1Content[IndexInItem]);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                        {
                            if (Console.CursorLeft <= 0)
                            {
                                Console.CursorTop--;
                            }
                            else
                            {
                                Console.CursorLeft++;
                            }
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                        {        
                            Console.CursorLeft--;
                        }
                    }
                  
                    while (ReadLineStr != "exitItem" && ReadLineStr != "exitSave")
                    {
                        ReadLineStr = Console.ReadLine();
                        if (ReadLineStr == "exitItem" || ReadLineStr == "exitSave")
                        {
                            if (File.Exists("SubItems1ContentLog.txt"))
                            {
                                SubItems1ContentList = File.AppendText("SubItems1ContentLog.txt");
                            }
                            else
                            {
                                SubItems1ContentList = File.CreateText("SubItems1ContentLog.txt");
                            }
                            if (File.Exists("SubItems2ContentLog.txt"))
                            {
                                SubItems2ContentList = File.AppendText("SubItems2ContentLog.txt");
                            }
                            else
                            {
                                SubItems2ContentList = File.CreateText("SubItems2ContentLog.txt");
                            }


                            foreach (var item in SubItems1Content)
                            {
                                SubItems1ContentList.WriteLine(item);
                            }
                            SubItems1ContentList.WriteLine("endOf" + "\n");
                            SubItems1ContentList.Close();
                        }
                        ModifiedContent.Add(ReadLineStr);
                        Joiner = String.Join("\n", ModifiedContent.ToArray());
                        SubItems1Content[IndexInItem] = Joiner;
                        
                    }
                }
                else if (MainIndex == 1)
                {
                    if (SubItems2Content[IndexInItem] != null)
                    {
                        Joiner = "none";
                        ModifiedContent.Clear();
                        Console.Write(SubItems2Content[IndexInItem]);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
                        {
                            if(Console.CursorLeft <= 0)
                            {
                                Console.CursorTop--;
                            }
                            else
                            {
                                Console.CursorLeft++;
                            }
                        }
                        else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                        {

                            Console.CursorLeft--;
                        }
                    }
                    
                    while (ReadLineStr != "exitItem" && ReadLineStr != "exitSave")
                    {
                        ReadLineStr = Console.ReadLine();
                        if (ReadLineStr == "exitItem" || ReadLineStr == "exitSave")
                        {
                            if (File.Exists("SubItems2ContentLog.txt"))
                            {
                                SubItems2ContentList = File.AppendText("SubItems2ContentLog.txt");
                            }
                            else
                            {
                                SubItems2ContentList = File.CreateText("SubItems2ContentLog.txt");
                            }
                            if (File.Exists("SubItems1ContentLog.txt"))
                            {
                                SubItems1ContentList = File.AppendText("SubItems1ContentLog.txt");
                            }
                            else
                            {
                                SubItems1ContentList = File.CreateText("SubItems1ContentLog.txt");
                            }

                            foreach (var item in SubItems2Content)
                            {
                                SubItems2ContentList.WriteLine(item);
                            }
                            SubItems2ContentList.WriteLine("endOf" + "\n");
                            SubItems2ContentList.Close();
                        }
                        ModifiedContent.Add(ReadLineStr);
                        Joiner = String.Join("\n", ModifiedContent.ToArray());
                        SubItems2Content[IndexInItem] = Joiner;
                    }


                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">> Content Modified Successfully, use lsItems --content-see to see it << ");
                Console.ForegroundColor = ConsoleColor.White;
                }
             
            

            






                
            





        }
          
    }
}
    

