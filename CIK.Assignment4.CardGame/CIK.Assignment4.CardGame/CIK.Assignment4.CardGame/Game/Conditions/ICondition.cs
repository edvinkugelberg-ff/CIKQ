using System;
using System.Collections.Generic;
using System.Text;
using CIK.Assignment4.CardGame.Models;

namespace CIK.Assignment4.CardGame.Services
{
    public interface ICondition
    {
        bool CheckCondition(IEnumerable<Card> hand);
    }
}
