using System;

namespace GeneticAlgorithm
{
    public class Chromosome:IChromosome
    {
        public ushort[] Genome { get; set; }
        public float Fitness { get; set; }

        public Chromosome(int genomeSize) => this.Genome=new ushort[genomeSize];

        public Chromosome(ushort[] genome) => this.Genome = genome;
        public void FillGenome()
        {
            Random random =new Random();
            for (int i = 0; i < Genome.Length; i++)
                Genome[i] = (ushort)(random.Next(0, 100)%2);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Genome.Length; i++)
            {
                str += Genome[i];
            }

            return str;
        }
    }
}