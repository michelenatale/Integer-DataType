﻿

namespace TestUIntX;

public class Program
{

  public static void Main()
  {

    TestInt128Ex.Start();
    TestUInt128Ex.Start();

    TestInt256Ex.Start();
    TestUInt256Ex.Start();

    TestInt512Ex.Start();
    TestUInt512Ex.Start();

    Console.WriteLine();
    Console.WriteLine("FINISH");
    Console.WriteLine();
    Console.ReadLine();
  }
}


