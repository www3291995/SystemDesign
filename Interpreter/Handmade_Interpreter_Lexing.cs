using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Interpreter
{
    class Handmade_Interpreter_Lexing
    {
        //static List<Token> Lex(string input)
        //{
        //    var result = new List<Token>();
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        switch (input[i])
        //        {
        //            case '+':
        //                result.Add(new Token(Token.Type.Plus, "+"));
        //                break;
        //            case '-':
        //                result.Add(new Token(Token.Type.Minus, "-"));
        //                break;
        //            case '(':
        //                result.Add(new Token(Token.Type.Lparen, "("));
        //                break;
        //            case ')':
        //                result.Add(new Token(Token.Type.Rparen, ")"));
        //                break;
        //            default:
        //                var sb = new StringBuilder(input[i].ToString());
        //                for (int j = i + 1; j < input.Length; j++)
        //                {
        //                    if (char.IsDigit(input[j]))
        //                    {
        //                        sb.Append(input[j]);
        //                        ++i;
        //                    }
        //                    else
        //                    {
        //                        result.Add(new Token(Token.Type.Integer, sb.ToString()));
        //                        break;
        //                    }
        //                }
        //                break;
        //        }
        //    }

        //    return result;
        //}

        //static void Main(string[] args)
        //{
        //    // ( 13 + 4 ) - ......token
        //    string input = "(13+4)-(12+1)";
        //    var tokens = Lex(input);
        //    WriteLine(string.Join("\t", tokens));




        //    // ------------------------------------
        //    ReadLine();
        //}
    }

    public class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen
        }

        public Type MyType;
        public string Text;

        public Token(Type myType, string text)
        {
            MyType = myType;
            Text = text;
        }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }
}
