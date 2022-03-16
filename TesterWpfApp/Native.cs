using RIS = System.Runtime.InteropServices;

namespace QuadrepAPI
{
    public static class Native
    {
        public const string DllName = "test.dll";
        public const RIS.CallingConvention CallingConvention = RIS.CallingConvention.Cdecl;
    }
}