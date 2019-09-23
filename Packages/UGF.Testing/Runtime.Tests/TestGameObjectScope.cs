using System;
using UnityEngine;

namespace UGF.Testing.Runtime.Tests
{
    public class TestGameObjectScope : TestObjectScope
    {
        public GameObject GameObject { get { return (GameObject)Target; } }

        public TestGameObjectScope(string name) : base(new GameObject(name))
        {
        }

        public TestGameObjectScope(string name, params Type[] components) : base(new GameObject(name, components))
        {
        }
    }
}
