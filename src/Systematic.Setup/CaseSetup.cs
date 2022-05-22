﻿namespace Systematic.Setup
{
    using System.Collections.Generic;

    using Systematic.Setup.Sequences;

    /// <summary>
    /// A setup of a test case.
    /// </summary>
    public class CaseSetup
    {
        /// <summary>
        /// Setups of sequences that make up the case.
        /// </summary>
        private readonly List<ISequenceSetup> _sequences = new List<ISequenceSetup>();

        /// <summary>
        /// Gets or sets a test case name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets setups of sequences that make up the case.
        /// </summary>
        public IReadOnlyCollection<ISequenceSetup> Sequences => _sequences;

        /// <summary>
        /// Adds a sequence setup to the case setup.
        /// </summary>
        /// <param name="sequence">A sequence setup.</param>
        public void AddSequence(ISequenceSetup sequence) => _sequences.Add(sequence);

        /// <summary>
        /// Removes a sequence setup from the case setup.
        /// </summary>
        /// <param name="sequence">A sequence setup.</param>
        public void RemoveSequence(ISequenceSetup sequence) => _sequences.Remove(sequence);

        /// <summary>
        /// Builds a test case based on the current setup.
        /// </summary>
        /// <returns>A test case.</returns>
        public Case Build()
        {
            var testCase = new Case(Name);

            var sequences = BuildSequences();
            foreach (var sequence in sequences)
                testCase.AddSequence(sequence);

            return testCase;
        }

        /// <summary>
        /// Builds sequences in the case from their setup.
        /// </summary>
        /// <returns>Sequences in the case.</returns>
        private IEnumerable<Sequence> BuildSequences()
        {
            foreach (var setup in Sequences)
                yield return setup.Build();
        }
    }
}
