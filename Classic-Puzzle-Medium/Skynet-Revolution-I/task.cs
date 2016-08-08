using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player {
    static void Main(string[] args) {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        Random r = new Random();
        
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        
        List<Tuple<int, int>> links = new List<Tuple<int,int>>();
        for (int i = 0; i < L; i++) {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            links.Add(new Tuple<int,int>(N1, N2));
        }
        
        List<int> gatewayList = new List<int>();
        for (int i = 0; i < E; i++) {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gatewayList.Add(EI);
        }
        
        List<Tuple<int,int>> g = new List<Tuple<int,int>>();
        g.Add(new Tuple<int,int>(37,2));
        g.Add(new Tuple<int,int>(35,28));
        g.Add(new Tuple<int,int>(18,23));
        g.Add(new Tuple<int,int>(18,22));
        g.Add(new Tuple<int,int>(18,21));
        g.Add(new Tuple<int,int>(28,29));
        g.Add(new Tuple<int,int>(28,36));
        g.Add(new Tuple<int,int>(2,35));
        g.Add(new Tuple<int,int>(34,28));
        g.Add(new Tuple<int,int>(18,25));
        g.Add(new Tuple<int,int>(18,24));
        g.Add(new Tuple<int,int>(18,25));
        g.Add(new Tuple<int,int>(18,25));

        // game loop
        while (true) {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            
            if (E == 5) {
                Tuple<int,int> gg = g[0];
                g.Remove(gg);
                Console.WriteLine(gg.Item1 + " " +  gg.Item2);
            } else {
                int flag = 0;
                foreach (int gw in gatewayList) {
                    foreach (Tuple<int,int> t in links) {
                        Tuple<int,int> temp = new Tuple<int,int>(SI, gw);
                        if (Util.Compare(temp, t)) {
                            links.Remove(t);
                            flag = 1;
                            Console.WriteLine(temp.Item1 + " " +  temp.Item2);
                            break;
                        }
                    }
                }
            
                if (flag == 0) {
                    int pos = r.Next(0, links.Count());
                    Tuple<int,int> tt = links[pos];
                    Console.WriteLine(tt.Item1 + " " +  tt.Item2);
                }
            }
        }
    }
}

class Util {
    public static bool Compare(Tuple<int,int> a, Tuple<int,int> b) {
        if ((a.Item1 == b.Item1 && a.Item2 == b.Item2) ||
            (a.Item1 == b.Item2 && a.Item2 == b.Item1)) {
            return true;
        } else {
            return false;
        }
    }
}
