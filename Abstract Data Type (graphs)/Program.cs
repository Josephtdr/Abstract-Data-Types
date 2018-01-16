using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Data_Type__graphs_ {
    class Program {
        static void Main(string[] args) {
            Graphs graph = new Graphs {
                RootVertex = (new Vertex {
                    data = "A",
                    LeftNode = new Vertex { data = "B", LeftNode = new Vertex { data = "D"}, RightNode = new Vertex { data = "E" } },
                    RightNode = new Vertex { data = "C" }
                })
            };

            Graphs test = new Graphs { };
            test.RootVertex = Graphs.createGraph();

            Graphs.Preorder(test.RootVertex);
            Console.WriteLine("\n");
            Graphs.Inorder(test.RootVertex);
            Console.WriteLine("\n");
            Graphs.Postorder(test.RootVertex);
            Console.ReadKey();
        }
    }

    class Vertex {
        public string data { get; set; }
        public Vertex LeftNode { get; set; }
        public Vertex RightNode { get; set; }
        public override string ToString() {
            return data;
        }
    }

    class Graphs {
        public Vertex RootVertex { get; set; }
        
        public static void Preorder(Vertex vertex) { // <root><left><right>
            if (vertex == null) return;
            Console.Write(vertex); //<root>
            Preorder(vertex.LeftNode); //<left>
            Preorder(vertex.RightNode);//<right>
        }
        public static void Inorder(Vertex vertex) { // <left><root><right>
            if (vertex == null) return;
            Inorder(vertex.LeftNode);//<left>
            Console.Write(vertex);//<root>
            Inorder(vertex.RightNode);//<right>
        }

        public static void Postorder(Vertex vertex) { // <left><right><root>
            if (vertex == null) return;
            Postorder(vertex.LeftNode);//<left>
            Postorder(vertex.RightNode);//<right>
            Console.Write(vertex);//<root>
        }

        public static Vertex createGraph() {
            Vertex vertex = new Vertex();
            Console.WriteLine("Please input vertex data in form [data]/[leftnode ? y/n]/[rightnode ? y/n].");
            string[] liststring = Console.ReadLine().Split('/');
            vertex.data = liststring[0];
            if (liststring[1] == "y")
                vertex.LeftNode = createGraph();
            if (liststring[2] == "y")
                vertex.RightNode = createGraph();
            return vertex;
        }

    }
}
