using System;
using System.Collections.Generic;
using System.Linq;

namespace NLogStart
{
    /// <summary>
    /// Dummy Depdendency Factory
    /// </summary>
    public static class DependencyFactory
    {
        /// <summary>
        /// List of dependencuies
        /// </summary>
        private static Dictionary<Type, Type> dependencies;

        /// <summary>
        /// initialiize dependency in constructor
        /// </summary>
        static DependencyFactory()
        {
            dependencies = new Dictionary<Type, Type>();
        }

        /// <summary>
        /// Register Dependency
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TType">Type to register</typeparam>
        public static void RegisterDependency<TInterface, TType>() where TType : TInterface
        {
            if (!typeof(TType).GetInterfaces().Contains(typeof(TInterface)))
            {
                throw new DependencyRegistrationExcepption("Type does not derive from the interface");
            }
            if (dependencies.Keys.Contains(typeof(TInterface)))
                dependencies[typeof(TInterface)] = typeof(TType);
            else
            {
                dependencies.Add(typeof(TInterface), typeof(TType));
            }
        }

        /// <summary>
        /// Resolves the Dependency
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public static TInterface Resolve<TInterface>()
        {
            if (dependencies.Keys.Contains(typeof(TInterface)))
            {
                try
                {
                    return (TInterface)Activator.CreateInstance(dependencies[typeof(TInterface)]);
                }
                catch 
                {
                    throw new DependencyResolutionExcepption("Unable to Resolve Dependency. Unable to create Instance");
                }
            }
            throw new DependencyResolutionExcepption("Unable to Resolve Dependency. Not Registered");
        }
    }

    /// <summary>
    /// Dependency Registraiton Exception
    /// </summary>
    internal class DependencyRegistrationExcepption : Exception
    {
        public DependencyRegistrationExcepption()
        {

        }

        public DependencyRegistrationExcepption(string message) : base(message)
        {

        }
    }
    /// <summary>
    /// Dependency Resolution Exception
    /// </summary>
    internal class DependencyResolutionExcepption : Exception
    {
        public DependencyResolutionExcepption()
        {

        }

        public DependencyResolutionExcepption(string message) : base(message)
        {

        }
    }
}
