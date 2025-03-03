﻿using NUnit.Framework;

namespace BananaParty.BehaviorTree.Tests
{
    public class ParallelFirstCompleteNodeTests
    {
        [Test]
        public void ShouldFinishWhenFirstChildCompletes()
        {
            InvocationTestNode[] testNodes = new[]
            {
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Running),
                new InvocationTestNode(BehaviorNodeStatus.Running)
            };

            var parallelNode = new ParallelFirstCompleteNode(testNodes);
            parallelNode.Execute(1);

            Assert.IsFalse(parallelNode.Finished, $"Finished too early.");

            testNodes[1].Status = BehaviorNodeStatus.Failure;

            parallelNode.Execute(2);

            Assert.IsTrue(parallelNode.Finished, $"Did not finish. {nameof(parallelNode.Status)} = {parallelNode.Status}");
        }
    }
}
