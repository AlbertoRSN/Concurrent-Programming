# THREADS IN C#

### ¿What is "Thread"?

A thread is defined as the execution path of a program. Each thread defines a unique flow of control. If your application involves complicated and time consuming operations, then it is often helpful to set different execution paths or threads, with each thread performing a particular job.


![thread](imgs/NewThread.png)
    



**Starting a thread in C#**
We can start a thread in C# by using the Thread class present under the System.Thread namespace in the following way.


```c#
using System.Threading;

 Thread t = new Thread(new ThreadStart(Go));
        t.Start();   // Run Go() on the new thread.
        Go();        // Simultaneously run Go() in the main thread.

        Thread t2 = new Thread(Go);    // No need to explicitly use ThreadStart
        t2.Start();

        Thread t3 = new Thread(() => Console.WriteLine("Lambda has created this thread"));
        t3.Start();

        Thread t4 = new Thread(() => Print("Our parameter"));
        t4.Start();

```

The output of the program CreatingThreads.cs:

![output](imgs/output.png)


**Information Source:**

*[https://www.tutorialspoint.com/](https://www.tutorialspoint.com/csharp/csharp_multithreading.htm)*
*[https://www.dotnetforall.com/](https://www.dotnetforall.com/multithreading-in-csharp-basics/)*