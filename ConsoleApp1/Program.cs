using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithm;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fitnessFunc =new FitnessFunction();
            var population = new Population(100, 100, 50, 9, fitnessFunc);
            var mutator = new Mutator(0.05f);
            GeneticAlgorithm.GeneticAlgorithm gen = new GeneticAlgorithm.GeneticAlgorithm(population,mutator);
            gen.Evaluate();
            Game game =new Game(20);
            game.InitWorld();
            game.AddBactery(gen.BestChromosome.Genome);
            game.Print();
            Console.ReadKey();


        }
    }
}
