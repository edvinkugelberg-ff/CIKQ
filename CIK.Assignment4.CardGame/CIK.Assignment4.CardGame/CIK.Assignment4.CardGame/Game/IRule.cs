using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame.Game
{
    public interface IRule
    {
        string RuleName { get; }
        bool CheckConditions(IEnumerable<Card> hand);
    }
}
