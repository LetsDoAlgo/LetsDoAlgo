using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{


    //char id;      // Job Id 
    //int dead;    // Deadline of job 
    //int profit;  // Profit if job is over 
    class Program
    {
        static void Main(string[] args)
        {
            String[] array = { "abc", "xyz",
                    "abcd", "bcd", "abc" };

            LexicographicOrder.Trie trie = new LexicographicOrder.Trie();

            for (int i_trie = 0; i_trie < array.Length; i_trie++)
            {
                trie.insert(array[i_trie], i_trie);
            }

            trie.traversePreorder(array);

            /////////////////////////////////////////////////////

            TreeAncestor.BinaryTree tree_ances = new TreeAncestor.BinaryTree();

            /* Construct the following binary tree  
                    1  
                    / \  
                2     3  
                / \  
                4 5  
                /  
            7  
            */
            tree_ances.root = new TreeAncestor.Node(1);
            tree_ances.root.left = new TreeAncestor.Node(2);
            tree_ances.root.right = new TreeAncestor.Node(3);
            tree_ances.root.left.left = new TreeAncestor.Node(4);
            tree_ances.root.left.right = new TreeAncestor.Node(5);
            tree_ances.root.left.left.left = new TreeAncestor.Node(7);

            tree_ances.printAncestors(tree_ances.root, 7);
            ////////////////////////////////////////////////////////////////
            int[] number = { 2, 3, 4 };
            int n_phone = number.Length;
            PhoneNumberCombinations.letterCombinations(number, n_phone);


            int[] arr_Water = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine("Maximum water that can be accumulated is " +
                       TrappingRainWater.findWater(arr_Water,arr_Water.Length));
            ////////////////////////////////////////////////////////

            int[] ar1_med = { 1, 12, 15, 26, 38 };
            int[] ar2_med = { 2, 13, 17, 30, 45 };

            int n1 = ar1_med.Length;
            int n2 = ar2_med.Length;
            if (n1 == n2)
                Console.Write("Median is " +CalcMedian.getMedian(ar1_med, ar2_med, n1));
            else
                Console.Write("arrays are of unequal size");
       
        //int x = 40;
        // GFG obj = new GFG();
        BFS_JumpingNumbers.printJumping(40);
         
            SortByFreq.CustomSort s1 = new SortByFreq.CustomSort();
            int[] arr_fr = {3,3,1,1,1,1,8,3,6,8,7,8 };
            s1.customSort2(arr_fr);
            //////////////////////////////////////////////
            int[] arr_coin = { 3, 3, 4 };
            int n_coin = arr_coin.Length;
            int x_coin = 7;

            Console.WriteLine(CoinChangeDenomination.minNumbers(x_coin, arr_coin, n_coin));
            //////////////////////////////////////////////////////
            int m_mat = 2;
            int n_mat = 3;
            int[,] matri = { { 1, 2, 3 },
                        { 4, 5, 6 } };
            int maxLengthOfPath = m_mat + n_mat - 1;
            Path_2DMatrix.printMatrix(matri, m_mat, n_mat, 0, 0, new int[maxLengthOfPath], 0);
            ///////////////////////////////////////////////////////////////////////
            int N_cyc = 5674;
            Permutation_Cyclic.cyclic(N_cyc);
            ///////////////////////////////////////////////////////////
            String str_1231 = "4697557964";
            char[] num = str_1231.ToCharArray();
            int n_1231 = str_1231.Length;
            Permutation_PALINDROME_Next.nextPalin(num, n_1231);
            /////////////////////////////////////////////////////////////////
            // n is the number of nodes i.e. V 
            int n_tsp = 4;

            int[,] graph_tsp = {
        { 0, 10, 15, 20 },
        { 10, 0, 35, 25 },
        { 15, 35, 0, 30 },
        { 20, 25, 30, 0 }
    };

            // Boolean array to check if a node 
            // has been visited or not 
            bool[] v_tsp = new bool[n_tsp];

            // Mark 0th node as visited 
            v_tsp[0] = true;
            int ans = int.MaxValue;

            // Find the minimum weight Hamiltonian Cycle 
            ans = ShortestPath_TSP_Hamiltonian.tsp(graph_tsp, v_tsp, 0, n_tsp, 1, 0, ans);

            // ans is the minimum weight Hamiltonian Cycle 
            Console.Write(ans);
            /////////////////////////////////////////////////////////////////////////
            int[] arr_jump = { 1, 3, 6, 1, 0, 9 };
            Console.Write("Minimum number of jumps to reach end is : " +
                                       MinJumpsInArray.MinJumps_DP(arr_jump, arr_jump.Length));
            MinJumpsInArray.minJumps_N(arr_jump);
       
            ////////////////////////////////////////////////////////////
            Node root_x = new Node(1);
            root_x.left = new Node(3);
            root_x.left.left = new Node(2);
            root_x.left.right = new Node(1);
            root_x.left.right.left = new Node(1);
            root_x.right = new Node(-1);
            root_x.right.left = new Node(4);
            root_x.right.left.left = new Node(1);
            root_x.right.left.right = new Node(2);
            root_x.right.right = new Node(5);
            root_x.right.right.right = new Node(2);

            int k_x = 5;
            BinaryTreeSun b1 = new BinaryTreeSun();
            b1.PrintKPath(root_x, k_x);
            //////////////////////////////////////////////////////////////////
            SortedArrayToBST.Node root__;
             SortedArrayToBST.BinaryTree tree__ = new SortedArrayToBST.BinaryTree();
            int[] arr__ = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n__M = arr__.Length;
            root__ = tree__.sortedArrayToBST(arr__, 0, n__M - 1);
            Console.WriteLine("Preorder traversal of constructed BST");
            tree__.preOrder(root__);
            //////////////////////////////////////////////////////////////////
            //int[] number = { 2, 3 , 4  };
            //int n_phone = number.Length;
            //PhoneNumberCombinations.letterCombinations(number, n_phone);
            ///////////////////////////////////////////////////
            int[] a_l = { 6, 5, 1, 2, 3, 2, 1, 4, 5 };
            int n_l = a_l.Length;
            int k_l = 3;
           Fruits_Baskets.Longest(a_l, n_l, k_l);

            ////////////////////////////////////////////
            int[] data = { 5, 9, 6, 2, 4, 8, 3, 1 };
           MaxProfit_Stocks.DoTest(data);

            /////////////////////////////////////////////
            LexicographicOrder lexico = new LexicographicOrder();

         
              


            //    // function to sort an array 
            //    // of strings using Trie 
            //    static void printInSortedOrder(String[] array)
            //    {
    
            //}
            //   lexico.Print(12);
            //////////////////////////////////////////////////////////////////////
            int k_merge = 3; // Number of linked lists  
            int n_merge = 4; // Number of elements in each list  

            // An array of pointers storing the head nodes  
            // of the linked lists  
            MergeKSortedList.Node[] arr_merge = new MergeKSortedList.Node[k_merge];

            arr_merge[0] = new MergeKSortedList.Node(1);
            arr_merge[0].next = new MergeKSortedList.Node(3);
            arr_merge[0].next.next = new MergeKSortedList.Node(5);
            arr_merge[0].next.next.next = new MergeKSortedList.Node(7);
          
            arr_merge[1] = new MergeKSortedList.Node(2);
            arr_merge[1].next = new MergeKSortedList.Node(4);
            arr_merge[1].next.next = new MergeKSortedList.Node(6);
            arr_merge[1].next.next.next = new MergeKSortedList.Node(8);
          
            arr_merge[2] = new MergeKSortedList.Node(0);
            arr_merge[2].next = new MergeKSortedList.Node(9);
            arr_merge[2].next.next = new MergeKSortedList.Node(10);
            arr_merge[2].next.next.next = new MergeKSortedList.Node(11);

            MergeKSortedList.Node head = MergeKSortedList.MergeKLists(arr_merge, k_merge - 1);
            ///////////////////////////////////////////////////////
            Console.WriteLine( Time_Closest.NextClosestTimeTwo("19:34"));
            ////////////////////////////////////////////////////
            LincenseKeyFormatting license = new LincenseKeyFormatting();
            license.LicenseKeyFormattingFind("5F3Z-3e-9-w", 4);

            //////////////////////////////////////////////////

           string[] Input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            GroupedAnagrams.FindGroupedAnagrams(Input);

            ////////////////////////////////////////////////
            string[] input = {"geeksforgeeks", "geeks","geek", "geezer"};

            Console.WriteLine("The longest Common" + " Prefix is : " + LCP.longestCommonPrefix(input));


            ///////////////////////////////////////////
            FindSubsets.powerSet("abc", -1, "");
            FindSubsets.printSubsets_Rec(new char[] { 'a', 'b', 'c' });


            //////////////////////////////////////////
            Merge2SortedList_ExtraSpace list1 = new Merge2SortedList_ExtraSpace();
            Merge2SortedList_ExtraSpace list2 = new Merge2SortedList_ExtraSpace();

            // Node head1 = new Node(5);  
            list1.addToTheLast(new Merge2SortedList_ExtraSpace.Node(5));
            list1.addToTheLast(new Merge2SortedList_ExtraSpace.Node(10));
            list1.addToTheLast(new Merge2SortedList_ExtraSpace.Node(15));

            // Node head2 = new Node(2);  
            list2.addToTheLast(new Merge2SortedList_ExtraSpace.Node(2));
            list2.addToTheLast(new Merge2SortedList_ExtraSpace.Node(3));
            list2.addToTheLast(new Merge2SortedList_ExtraSpace.Node(20));


            list1.head = list1.sortedMerge(list1.head, list2.head);
         //   llist1.printList();
            //////////////////////////////////////
            Merge2SortedList.Node head1 = Merge2SortedList.newNode(1);
            head1.next = Merge2SortedList.newNode(3);
            head1.next.next = Merge2SortedList.newNode(5);

            // 1.3.5 LinkedList created 

            Merge2SortedList.Node head2 = Merge2SortedList.newNode(0);
            head2.next = Merge2SortedList.newNode(2);
            head2.next.next = Merge2SortedList.newNode(4);

            // 0.2.4 LinkedList created 

            Merge2SortedList.Node mergedhead = Merge2SortedList.merge(head1, head2);

            Merge2SortedList.printList(mergedhead);

            //////////////////////////////////////
            FlipGame f1 = new FlipGame();
            f1.generatePossibleNextMove("++++");

            //////////////////////////////////

            int[,] mat =
        {
            { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0 },
            { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
            { 0, 1, 0, 1, 0, 0, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0 },
            { 0, 0, 0, 1, 0, 0, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 }
        };

            int M = mat.GetLength(0);
            int N = mat.GetLength(1);

            // stores if cell is processed or not
            bool[,] processed = new bool[M,N];

            int island = 0;
            for (int i1 = 0; i1 < M; i1++)
            {
                for (int j1 = 0; j1< N; j1++)
                {
                    // start BFS from each unprocessed node and
                    // increment island count
                    if (mat[i1,j1] == 1 && !processed[i1,j1])
                    {
                        Islands.BFS(mat, processed, i1, j1);
                        island++;
                    }
                }
            }

            Console.WriteLine("Number of islands are " + island);


            //////////////////////////////////////////////////

            string s_uni = "aabacbebebe";
            int k_uni = 3;
            GFG_.kUniques(s_uni, k_uni);
          


            /////////////////////////////////////////////////
        char[,] boggle = { { 'G', 'I', 'Z' },
                           { 'U', 'E', 'K' },
                           { 'Q', 'S', 'E' } };

            Console.WriteLine("Following words of " +
                              "dictionary are present");
            Boggle_DFS.findWords(boggle);



            ///////////////////////////////////////////////
            convert_number_to_words.convert_to_words("9923".ToCharArray());
            convert_number_to_words.convert_to_words("523".ToCharArray());

            ///////////////////////////////////////////////
            //trie///////////////////////////////////////////

            // List of Strings to represent dictionary
            string[] arr_tr =new string[] {"this", "th", "is", "famous",
                                        "word", "break", "b", "r", "e", "a", "k",
                                        "br", "bre", "brea", "ak", "prob", "lem" };

            // use trie to store dictionary
           Trie_Dictionary.Node t = new Trie_Dictionary.Node();
            Trie_Dictionary.Util tin = new Trie_Dictionary.Util();
            foreach (var item in arr_tr)
            {
                tin.InsertTrie(t, item);
            }
            // given String
            string str_tr = "wordbreakproblem";

            // check if String can be segmented or not
            if (tin.wordBreak(t, str_tr))
            {
                Console.WriteLine("String can be segmented");
            }
            else
            {
                Console.WriteLine("String can't be segmented");
            }



            var items = new List<string> { "armed", "armed", "jazz", "jaws" };
            var stream = new StreamReader(@"C:/word2.txt");
            while (!stream.EndOfStream)
                items.Add(stream.ReadLine());         

            //var trie = new Trie.TrieImplement();
            //var hashset = new HashSet<string>();
            //const string sg = "gau";

          
            //trie.InsertRange(items);
          
            //for (int t = 0; t < items.Count; t++)
            //    hashset.Add(items[t]);
           
            //var prefix = trie.Prefix(sg);
            //var foundT = prefix.Depth == sg.Length && prefix.FindChildNode('$') != null;
       

            //var foundL = hashset.FirstOrDefault(xs => xs.StartsWith(sg));


            //trie.Delete("jazz");
            //Console.Read();


            ///////////////////////////////////////////////

            int[] arr_Choc = new int[] { 2, 7, 6, 1, 4, 5 };
            int n_Choc = arr_Choc.Length;
            int k_Choc = 3;
            Console.Write("Maximum number of chocolates: " +
                            ChocolateDistributionProblem.maxNumOfChocolates(arr_Choc, n_Choc, k_Choc));

            ////////////////////////////////////////////////

            //GraphCycleDetection.Graph g = new GraphCycleDetection.Graph(4);
            //g.addEdge(0, 1);
            //g.addEdge(0, 2);
            //g.addEdge(1, 2);
            //g.addEdge(2, 0);
            //g.addEdge(2, 3);
            //g.addEdge(3, 3);

            //if (g.isCyclic())
            //    Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn’t contain cycle");
        
        ////////////////////////////////////////////////////

        MinimumCoins mj = new MinimumCoins();
            int[] arr_mj = new int[]{ 1, 3, 5, 3, 2, 2, 6, 1, 6, 8, 9 };
            int[] r= new int[arr_mj.Length];
            int result = mj.minJump(arr_mj, r);
            Console.WriteLine(result);
            int i = arr_mj.Length - 1;
            //Arrays.toString(r);
            arr_mj =new int[] { 2, 3, 1, 1, 4 };
            Console.WriteLine(mj.jump(arr_mj));



            //////////////////////////////////////////////////////
            int[] arr_heap = { 1, 3, 5, 4, 6, 13, 10,
                    9, 8, 15, 17 };

            int n_heap = arr_heap.Length;

            Heap_MinHeaptoMaxHeap.buildHeap(arr_heap, n_heap);

            Heap_MinHeaptoMaxHeap.PrintHeap(arr_heap, n_heap);


            ///////////////////////////////////////////////////////
            string txt = "BACDGABCDA";
            string pat = "ABCD";
            Permutation_Anagarm_SubstringSearch p1 = new Permutation_Anagarm_SubstringSearch();
                p1.search(pat, txt);

            ///////////////////////////////////////////////////////
            //Find largest bst 


            ///////////////////////////////////////////////////////////
            // Create stack of size 5  : find maximum with 1 stack in o(1)
            MaxElementStack_order_1.Stack S1 = new MaxElementStack_order_1.Stack(5);

            S1.Push(2);
            S1.max();
            S1.Push(6);
            S1.max();
            S1.pop();
            S1.max();
            /////////////////////////////////////////
            ///////1.pos///////////////////
            TreeTraversal t1 = new TreeTraversal();
            TreeTraversal.TreeNode root = new TreeTraversal.TreeNode(1);
            root.left = new TreeTraversal.TreeNode(2);
            root.right = new TreeTraversal.TreeNode(3);
            root.left.left = new TreeTraversal.TreeNode(4);
            root.left.right = new TreeTraversal.TreeNode(5);
            root.right.left = new TreeTraversal.TreeNode(6);
            root.right.right = new TreeTraversal.TreeNode(7);
            //t1.PostOrder_It(root);
            t1.LevelOrderTraversal(root);

         




            ////////////////////////////////////////////
            int n = 4;

                int[,] graph1 = {
                        { 0, 10, 15, 20 },
                        { 10, 0, 35, 25 },
                        { 15, 35, 0, 30 },
                        { 20, 25, 30, 0 }
                                };



            ////////////////////////////////////////////
            /* Let us create the example  
   graph discussed above */
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            ShortestPath sp = new ShortestPath();
            sp.djikshtraAlgo(graph, 0);


            int str1 = ReverseString.reverse(123456);
            //////////////////////////////////////////////

            List<string> l1 = new List<string>();
            l1.Add("a");
            l1.Add("b");
            l1.Add("c");

            List<int> l2 = new List<int>();
            l2.Add(1);
            l2.Add(2);
            l2.Add(3);
            var par = Permutation.Permutations(l2);



         

        //////////////////////////////////////////////
        int[] arr_nj = { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            int n__ = arr_nj.Length;
            Console.Write("Minimum number of jumps to reach end is "
                          +MinJumpsInArray.minJumps(arr_nj, 0, n__ - 1));

            /////////////////////////////////////////////
            char[] exp = { '{', '(', ')', '}', '[', ']' };
            if (BaalancedParenthesis.AreParenthesisBalanaced(exp))
                Console.WriteLine("Balanced ");
            else
                Console.WriteLine("Not Balanced ");

            //////////////////////////////////////////
            LinkedList llist = new LinkedList();

            /* Constructed Linked List is 1->2->3->4-> 
            5->6->7->8->8->9->null */
            llist.Push(0);
            llist.Push(1);
            llist.Push(0);
            llist.Push(2);
            llist.Push(1);
            llist.Push(1);
            llist.Push(2);
            llist.Push(1);
            llist.Push(2);
          
            Console.WriteLine("Linked List before sorting");
          //  llist.printList();




            ////////////////////////////////////////////
            int[] arrz = { 2, -6, -3, 8, 4, 1 };

            int nz = arrz.Length;

            SortPositiveNumbersOnly.sortArray(arrz, nz);


            /////////////////////////////////////////////////////
            string str123 = "aabacbebebe";
            int k = 3;
            GFG_.kUniques(str123, k);

            //////////////////////////////////////////////////

            int[] arr32 = {12, 4, 7, 9, 2, 23,
                    25, 41, 30, 40, 28,
                    42, 30, 44, 48, 43,
                                    50};

            int m = 7; // Number of students 

            int n32 = arr32.Length;

            Console.WriteLine("Minimum difference is "
                        + ChocolateDistributionProblem.findDiff(arr32, n32, m));


            ///////////////////////////////////////////////////////////////
            //{'a', 2, 100}, {'b', 1, 19}, {'c', 2, 27}, 
            // { 'd', 1, 25}, { 'e', 3, 15}
            Job[] jobs = new Job[] { new Job { Id =1, dead=2 , profit=100},
                                     new Job { Id=2 , dead=1 , profit = 19 },
                                     new Job { Id=3 , dead=2 , profit=27},
                                     new Job { Id=4 , dead=1,  profit=25 },
                                     new Job { Id=5,  dead=3,  profit=15} };
            JobSequencingProblem.printJobScheduling(jobs, jobs.Length);

            ///////////////////////////////////////////////////////////
            int[] arr_sum = new int[] { 10, 2, -2, -20, 10 };
            int n_23 = arr_sum.Length;
            int sum_23 = -10;
            SubArraySum.subArraySum(arr_sum, n_23, sum_23);



            /////////////////////////////////////////////////////////////
            LengthRootToLeaf.PrintRootToLeafPath tree3 = new LengthRootToLeaf.PrintRootToLeafPath();
            tree3.root = new LengthRootToLeaf.Node(10);
            tree3.root.left = new LengthRootToLeaf.Node(8);
            tree3.root.right = new LengthRootToLeaf.Node(2);
            tree3.root.left.left = new LengthRootToLeaf.Node(3);
            tree3.root.left.right = new LengthRootToLeaf.Node(5);
            tree3.root.right.left = new LengthRootToLeaf.Node(2);         
            tree3.printPath(tree3.root);

            LengthRootToLeaf.PrinMaxSUMtRootToLeafPath tree4 = new LengthRootToLeaf.PrinMaxSUMtRootToLeafPath();
            tree4.root = new LengthRootToLeaf.Node(4); //        4 
            tree4.root.left = new LengthRootToLeaf.Node(2); //       / \ 
            tree4.root.right = new LengthRootToLeaf.Node(5); //      2   5 
            tree4.root.left.left = new LengthRootToLeaf.Node(7); //     / \ / \ 
            tree4.root.left.right = new LengthRootToLeaf.Node(1); //    7  1 2  3 
            tree4.root.right.left = new LengthRootToLeaf.Node(2); //      / 
            tree4.root.right.right = new LengthRootToLeaf.Node(3); //     6 
            tree4.root.left.right.left = new LengthRootToLeaf.Node(6);
           
            Console.WriteLine("Max Sum"+tree4.sumOfLongRootToLeafPathUtil(tree4.root));
            
            SumRootToLeaf.SumBST tree1 = new SumRootToLeaf.SumBST();
            tree1.root = new SumRootToLeaf.Node(6);
            tree1.root.left = new SumRootToLeaf.Node(3);
            tree1.root.right = new SumRootToLeaf.Node(5);
            tree1.root.right.right = new SumRootToLeaf.Node(4);
            tree1.root.left.left = new SumRootToLeaf.Node(2);
            tree1.root.left.right = new SumRootToLeaf.Node(5);
            tree1.root.left.right.right = new SumRootToLeaf.Node(4);
            tree1.root.left.right.left = new SumRootToLeaf.Node(7);

            Console.Write("Sum of all paths is " +
                           tree1.treePathsSum(tree1.root));
            ////////////////////////////////////////////////////////////

            int[,] screen = {{1, 1, 1, 1, 1, 1, 1, 1},
                            {1, 1, 1, 1, 1, 1, 0, 0},
                            {1, 0, 0, 1, 1, 0, 1, 1},
                            {1, 2, 2, 2, 2, 0, 1, 0},
                            {1, 1, 1, 2, 2, 0, 1, 0},
                            {1, 1, 1, 2, 2, 2, 2, 0},
                            {1, 1, 1, 1, 1, 2, 1, 1},
                            {1, 1, 1, 1, 1, 2, 2, 1}};
            int x = 4, y = 4, newC = 3;
           GFG.floodFill(screen, x, y, newC);

            Console.WriteLine("updated screen after"+  "call to floodFill: ");
            for (int kt = 0; kt < 8; kt++)
            {
                for (int j = 0; j < 8; j++) Console.Write(screen[kt, j] + " "); Console.WriteLine();
            }



            //////////////////////////////////////////////////////////////////////
            string[] dict = { "ale", "apple", "monkey", "plea" };
            var str = "abpcplea";
            var output = LCSModified.FindLongestString(dict.ToList(), str);

            char[] set1 = { 'a', 'b' };
             k = 3;
           Permutation.printAllKLength(set1, k);



            //List<string> l1 = new List<string>();
            //l1.Add("a");
            //l1.Add("b");
            //l1.Add("c");

            //List<int> l2 = new List<int>();
            //l2.Add(1);
            //l2.Add(2);
            //l2.Add(3);
            //var par =  Permutation.Permutations(l2);


            ////////////////////////////////////////////////
            /////////////////generate n bit wildcard///////////
            char[] pattern = "1?0?1?1".ToCharArray();
              BinaryStringWildCardPattern.printAllCombination2(pattern, 0);
          //  int nb = 4;

            //int[] arrb = new int[nb];

            // Print all binary strings 
          //  BinaryStringWildCardPattern.generateAllBinaryStrings(nb, arrb, 0);
           // BinaryStringWildCardPattern.printAllCombonationsSTACK(pattern.ToString());

            ////////////////////////////////////////////////
            KSmallestBST.BST tree = new KSmallestBST.BST();

            /* Let us create following BST  
                  50  
               /     \  
              30      70  
             /  \    /  \  
           20   40  60   80 */

            tree.insert(50);
            tree.insert(30);
            tree.insert(20);
            tree.insert(40);
            tree.insert(70);
            tree.insert(60);
            tree.insert(80);

            tree.secondLargest(tree.root);
            ///////////////////////////////////////////////
            //trying ///////

            int[] arr_ = { 1, 2, 3, 4, 5 };
            int n_ = arr_.Length;
            int sum_ = 10;

            FindSubsetsWithSum_DP.Printsubset(arr_, n_, sum_);
            ////////////////////////////////////////////////
            int[] arrx = { 1, 2, 3, 4, 5 };
            int nx = arrx.Length;
            int sumx = 10;

            FindSubsetsWithSum_DP.Printsubset(arrx, nx, sumx);
            //////////////////////////////////////////
            int[] arr11 = { 2, 5, 8, 4, 6, 11 };
            int sum = 13;
            n = arr11.Length;
            FindSubsetsWithSum.printAllSubsets(arr11, n, sum);

            /////////////////////////////////////////////
            ////////////Combinations//////////////////////
            FindSubsets.FindSubsets123();

            ///////////////////////////////////////////
            //////////issubstring/////////////////////
            String A = "abcd", B = "cdabcdab";

            // Function call 
            Console.WriteLine(Substring.Min_repetation(A, B));

            ////////////////////////////////////////////
            /////////////max sum BinaryTree///////////
            //BinaryTree tree = new BinaryTree();
            //tree.root = new Node(10);
            //tree.root.left = new Node(2);
            //tree.root.right = new Node(10);
            //tree.root.left.left = new Node(20);
            //tree.root.left.right = new Node(21);

            ////////////////////////////////////////////
            //////////permutation of string /////////////
            //int i;
           
      int[] arr1 = new int[] { 1,2,3};
        
        Console.WriteLine("\n\n Recursion : Generate all possible permutations of an array :");
		Console.WriteLine("------------------------------------------------------------------");           
        Console.Write(" Input the number of elements to store in the array [maximum 5 digits ] :");
    
        n = 3;
     
        Console.Write ("\n The Permutations with a combination of {0} digits are : \n",n);
        Permutation.prnPermut(arr1, 0, n-1);
        Console.Write ("\n\n");


            ////////////////////////////////////////////
            ////////////max meeting/////////////////////
            // Starting time 
            int[] s = { 1, 3, 0, 5, 8, 5 };

            // Finish time 
            int[] f = { 2, 4, 6, 7, 9, 9 };

            // Number of meetings. 
             n = s.Length;

            // Fuction call 
           MaxMeeting.MaxMeetingFind(s, f, n);


            ////////////////////////////////////////////
            /////////////LCS///////////////////////////
            String X = "AGGTAB";
            String Y = "GXTXAYB";
             m = X.Length;
             n = Y.Length;
           LCS.lcs(X, Y, m, n);


            ///////////////////////////////////////////
            ////////min coins/////////////////////////

            int[] coins = { 9, 6, 5, 1 };
             m = coins.Length;
            int V = 11;
            Console.WriteLine("Minimum coins required is " +
                                    MinimumCoins.minCoins(coins, m, V));



            /////////////////////////////////////////
            ////////alien language///////////////////
            string[] words = { "caa", "aaa", "aab" };
            OrderOfCharacters.printOrdrer(words, 3);

            ///////////////////////////////////////////
            ////////////G1////////////////////////////


            int[] arr = { 12, 3, 5, 7, 4, 19, 26 };
             k = 5;
            Console.Write("K'th smallest element is " +
                    KthSmallest.QuickSort(arr, 0, arr.Length - 1, k));


            /////////////////////////////////////////////
            /////////////BFS PATH PRINT//////////////////
            var verticesB = new[] {1,2,3,4,5,6,7,8,9,10 };
            var edgesB = new[] {Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graphB = new GraphsBFS<int>(verticesB,edgesB);
            var algorithmsB = new AlgorithmsBFS();
            var path = new List<int>();
            Console.WriteLine(string.Join(",",algorithmsB.BFSPath(graphB,1,v=>path.Add(v))));
            Console.WriteLine(",",path);
            /////////////////////////////////////////////////
            ///////////////////DFS PATH PRINT///////////////
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            //var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

         //   Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1)));
//# 1, 3, 6, 5, 8, 9, 10, 7, 4, 2


            ////////////////////////////////////////////////

            //var ret =TopologicalSort1.TopologicalSort(new HashSet<int>(new[] { 7, 5, 3, 8, 11, 2, 9, 10 }),
            //                               new HashSet<Tuple<int, int>>(
            //                                              new[] { Tuple.Create(7, 11),
            //                                                      Tuple.Create(7, 8),
            //                                                      Tuple.Create(5, 11),
            //                                                      Tuple.Create(3, 8),
            //                                                      Tuple.Create(3, 10),
            //                                                      Tuple.Create(11, 2),
            //                                                      Tuple.Create(11, 9),
            //                                                      Tuple.Create(11, 10),
            //                                                      Tuple.Create(8, 9)
            //                                                       }
            //                                            ));

            var ret = TopologicalSort1.TopologicalSort(new HashSet<string>(new[] { "A", "B", "C", "D", "E", "F", "G", "H" }),
                                          new HashSet<Tuple<string, string>>(
                                                         new[] { Tuple.Create("A", "C"),
                                                                  Tuple.Create("B", "C"),
                                                                  Tuple.Create("C", "E"),
                                                                  Tuple.Create("E", "H"),
                                                                  Tuple.Create("E", "F"),
                                                                 Tuple.Create("B", "D"),
                                                                 Tuple.Create("D", "F"),
                                                                 Tuple.Create("F", "G")
                                                                  }
                                                       ));

            ////////////////////////////////////////////////
            ////union and intersection
            //LinkedList l1 = new LinkedList();
            //LinkedList l2 = new LinkedList();
            //l1.Push(20);
            //l1.Push(4);
            //l1.Push(15);
            //l1.Push(10);

            //l2.Push(10);
            //l2.Push(2);
            //l2.Push(4);
            //l2.Push(8);
            //Console.WriteLine("Printing L1");
            //l1.PrintList();

            //Console.WriteLine("Printing L2");
            //l2.PrintList();

            //LinkedList intLL = new LinkedList();
            //intLL.GetIntersect(l1.head, l2.head);
            //intLL.PrintList();
            //Console.ReadKey();
            ////////////////////////////////////////////////

            //int[] arr1 = {11,1,13,21,3,7 };
            //int[] arr2 = { 11, 3, 7, 1 };
            //int m = arr1.Length;
            //int n = arr2.Length;
            //if (isSubset(arr1,arr2,m,n))
            //{
            //    Console.WriteLine("arr2[] is subset of arr1[]");
            //}
            //else
            //    Console.WriteLine("arr2[] is not a subset of another rray");
        }

        static bool isSubset(int[] arr1, int[] arr2, int m, int n)
        {
            int i = 0;
            sort(arr1,0,m-1);
            for (i = 0; i < n; i++)
            {
                if (binarySearch(arr1,0,m-1,arr2[i])==-1)
                {
                    return false;
                }
               
            }
            return true;
        }

        static int binarySearch(int[] arr, int low, int high, int x)
        {
            if (high >= low)
            {
                int mid = (high + low) / 2;
                if ((mid == 0 || x > arr[mid - 1]) && arr[mid] == x)
                {
                    return mid;
                }
                else if (x > arr[mid])
                {
                    return binarySearch(arr, (mid + 1), high, x);
                }
                else
                    return binarySearch(arr, low, (mid - 1), x);
            }
            return -1;
        }

        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            int temp = 0;
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    j++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp;
            return i + 1;
        }

        static void sort(int[] arr , int low , int high)
        {
            if (low<high)
            {
                int pi = partition(arr, low, high);
                sort(arr, low, pi - 1);
                sort(arr, pi + 1, high);
            }
        }
    }
}
