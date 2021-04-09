using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Game;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame.Services
{
    public class Rule : IRule
    {
        private readonly List<ICondition> _conditions;
        public string RuleName { get; }

        public Rule(List<ICondition> conditions, string ruleName)
        {
            _conditions = conditions;
            RuleName = ruleName;
        }

        public bool CheckConditions(IEnumerable<Card> hand)
        {
            foreach (var condition in _conditions)
            {
                if (!condition.CheckCondition(hand)) return false;
            }

            return true;
        }
    }
}
