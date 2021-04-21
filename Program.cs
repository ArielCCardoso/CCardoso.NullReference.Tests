using System;

namespace CCardoso.NullReference.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Test A = new Test() { prop = "A" };
            Test B = new Test();
            Test C = new Test();
            Test D = new Test();
            Test NullTest = null;

            if (!A.prop.Equals(B.prop))
                Console.WriteLine("Objeto A diferente de B");
            if (A.prop != B.prop)
                Console.WriteLine("Objeto A diferente de B");

            // Build FAILED. error CS0165: Use of unassigned local variable 'NullTest'
            //Test NullTest;
            //if (!A.prop.Equals(NullTest.prop))
            //    Console.WriteLine("Objeto A diferente de NullTest");
            //if (A.prop != NullTest.prop)
            //    Console.WriteLine("Objeto A diferente de NullTest");

            // Build succeeded.
            //// Mas ocorre exceção 
            //if (!A.prop.Equals(NullTest.prop)) // System.NullReferenceException: 'Object reference not set to an instance of an object.'
            //    Console.WriteLine("Objeto A diferente de A2");
            //if (A.prop == NullTest.prop) // System.NullReferenceException: 'Object reference not set to an instance of an object.'
            //    Console.WriteLine("Objeto A diferente de A2");

            // Ocorre exceção - System.NullReferenceException: 'Object reference not set to an instance of an object.'
            //if (!C.prop.Equals(NullTest?.prop)) // Isso porque o Equals() é um método da classe string da propriedade 'prop' e neste caso, seu valor é nulo.
            //    Console.WriteLine("Objeto C diferente de A2");

            // Não ocorre exceção mas é arriscao, pois em casos que o objeto tbm for nulo, ocorrerá exceção
            if (C.prop == D.prop)
                Console.WriteLine("Objeto C igual a D");

            // Não ocorre exceção
            if (C?.prop == NullTest?.prop) // Melhor solução, usar a comparação através de operador de igualdade e usar o operador condicional nullo
                Console.WriteLine("Objeto C igual a NullTest");

            // Uma outra solução é atribuir algum valor default caso seja nulo.
            // Aqui usamos o operador de atribuição de coalescência nula
            D.prop ??= "nulo";
            if (D?.prop != NullTest?.prop)
                Console.WriteLine("Objeto D diferente de NullTest");

            Console.WriteLine("Fim");
            Console.ReadKey();
        }
    }
    class Test
    {
        public string prop;
    }
}
