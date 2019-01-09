namespace GeneticAlgorithm
{
    public interface IChromosome
    {
        ushort[] Genome { get; set; }
        float Fitness { get; set; }
        void FillGenome();
    }
}