using System.Collections.Generic;

namespace BitCoin.BitBus
{
    public class Tx
    {
        public string h { get; set; }
    }

    public class E
    {
        public string h { get; set; }
        public long i { get; set; }
        public string a { get; set; }
    }

    public class In
    {
        public long i { get; set; }
        public string b0 { get; set; }
        public string b1 { get; set; }
        public string str { get; set; }
        public E e { get; set; }
        public string h0 { get; set; }
        public string h1 { get; set; }
    }

    public class B0
    {
        public long op { get; set; }
    }

    public class E2
    {
        public long v { get; set; }
        public long i { get; set; }
        public string a { get; set; }
    }

    public class Out
    {
        public long i { get; set; }
        public B0 b0 { get; set; }
        public object b1 { get; set; }
        public string s1 { get; set; }
        public string b2 { get; set; }
        public string s2 { get; set; }
        public object b3 { get; set; }
        public string s3 { get; set; }
        public object b4 { get; set; }
        public string s4 { get; set; }
        public string b5 { get; set; }
        public string s5 { get; set; }
        public string b6 { get; set; }
        public string s6 { get; set; }
        public string b7 { get; set; }
        public string s7 { get; set; }
        public string b8 { get; set; }
        public string s8 { get; set; }
        public string b9 { get; set; }
        public string s9 { get; set; }
        public string b10 { get; set; }
        public string s10 { get; set; }
        public string b11 { get; set; }
        public string s11 { get; set; }
        public string b12 { get; set; }
        public string s12 { get; set; }
        public string b13 { get; set; }
        public string s13 { get; set; }
        public string b14 { get; set; }
        public string s14 { get; set; }
        public string b15 { get; set; }
        public string s15 { get; set; }
        public string b16 { get; set; }
        public string s16 { get; set; }
        public string b17 { get; set; }
        public string s17 { get; set; }
        public string b18 { get; set; }
        public string s18 { get; set; }
        public string b19 { get; set; }
        public string s19 { get; set; }
        public string b20 { get; set; }
        public string s20 { get; set; }
        public string b21 { get; set; }
        public string s21 { get; set; }
        public string b22 { get; set; }
        public string s22 { get; set; }
        public string b23 { get; set; }
        public string s23 { get; set; }
        public string b24 { get; set; }
        public string s24 { get; set; }
        public string b25 { get; set; }
        public string s25 { get; set; }
        public string b26 { get; set; }
        public string s26 { get; set; }
        public string b27 { get; set; }
        public string s27 { get; set; }
        public E2 e { get; set; }
        public string h1 { get; set; }
        public string h2 { get; set; }
        public string h3 { get; set; }
        public string h4 { get; set; }
        public string h5 { get; set; }
        public string h6 { get; set; }
        public string h7 { get; set; }
        public string h8 { get; set; }
        public string h9 { get; set; }
        public string h10 { get; set; }
        public string h11 { get; set; }
        public string h12 { get; set; }
        public string h13 { get; set; }
        public string h14 { get; set; }
        public string h15 { get; set; }
        public string h16 { get; set; }
        public string h17 { get; set; }
        public string h18 { get; set; }
        public string h19 { get; set; }
        public string h20 { get; set; }
        public string h21 { get; set; }
        public string h22 { get; set; }
        public string h23 { get; set; }
        public string h24 { get; set; }
        public string h25 { get; set; }
        public string h26 { get; set; }
        public string h27 { get; set; }
    }

    public class Blk
    {
        public long i { get; set; }
        public string h { get; set; }
        public long t { get; set; }
    }

    public class Transaction
    {
        public string _id { get; set; }
        public Tx tx { get; set; }
        public List<In> @in { get; set; }
        public List<Out> @out { get; set; }
        public Blk blk { get; set; }
        public long i { get; set; }
    }
}
