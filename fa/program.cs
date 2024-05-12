using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
  public class State
  {
    public string Name;
    public Dictionary<char, State> Transitions;
    public bool IsAcceptState;
  }


  public class FA1
  {
    public static readonly State a = new State { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State b = new State { Name = "b", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
    public static readonly State с = new State { Name = "с", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

    public static readonly State InitialState = a;
    public FA1()
    {
      a.Transitions['0'] = b;
      a.Transitions['1'] = a;

      b.Transitions['1'] = с;
      
      с.Transitions['1'] = с;
    }

    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        if (!current.Transitions.TryGetValue(c, out current)) return false;
      }
      return current.IsAcceptState;
    }
  }

  public class FA2
  {
    public static readonly State a = new State() { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State b = new State() { Name = "b", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State c = new State() { Name = "c", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State d = new State() { Name = "d", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

    public static readonly State InitialState = a;

    public FA2()
    {
      a.Transitions['0'] = b;
      a.Transitions['1'] = c;

      b.Transitions['0'] = a;
      b.Transitions['1'] = d;

      c.Transitions['0'] = d;
      c.Transitions['1'] = a;

      d.Transitions['0'] = c;
      d.Transitions['1'] = b;
    }
    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        if (!current.Transitions.TryGetValue(c, out current)) return false;
      }
      return current.IsAcceptState;
    }
  }

  public class FA3
  {
    public static readonly State a = new State() { Name = "a", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State b = new State() { Name = "b", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State c = new State() { Name = "c", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
    public static readonly State d = new State() { Name = "d", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

    public static readonly State InitialState = a;

    public FA3()
    {
      a.Transitions['0'] = b;
      a.Transitions['1'] = c;

      b.Transitions['0'] = a;
      b.Transitions['1'] = c;

      c.Transitions['0'] = a;
      c.Transitions['1'] = d;

      d.Transitions['0'] = d;
      d.Transitions['1'] = d;
    }

    public bool? Run(IEnumerable<char> s)
    {
      State current = InitialState;
      foreach (var c in s)
      {
        if (!current.Transitions.TryGetValue(c, out current)) return false;
      }
      return current.IsAcceptState;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}