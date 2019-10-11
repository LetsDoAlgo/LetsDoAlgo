using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    // digraph G {
    //   "7"  -> "11"
    //   "7"  -> "8"
    //   "5"  -> "11"
    //   "3"  -> "8"
    //   "3"  -> "10"
    //   "11" -> "2"
    //   "11" -> "9"
    //   "11" -> "10"
    //   "8"  -> "9"
   static class TopologicalSort1
    {
       public static List<T> TopologicalSort<T>(HashSet<T> nodes, HashSet<Tuple<T,T>> edges) where T:IEquatable<T>
        {
            var list = new List<T>();
            var set = new HashSet<T>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) == false)));
            while (set.Any())
            {
                //remve node form set
                var n = set.First();
                set.Remove(n);

                //add n to tail of L
                list.Add(n);

                //for each node m with an edge e from n to m do
                var edgesd = edges.Where(e => e.Item1.Equals(n)).ToList();
                foreach (var e in edges.Where(e=>e.Item1.Equals(n)).ToList())
                {
                    var m = e.Item2;
                    edges.Remove(e);
                    //if m has no other incoming edges then 
                    var sd = edges.All(x => x.Item2.Equals(m) == false);
                    if (sd)
                    {
                        set.Add(m);
                    }
                } 
            }

            if (edges.Any())
            {
                return null;
            }
            else
            {
                return list;
            }

        }
       
        //////////////////////////////////////////////////

    }
}
