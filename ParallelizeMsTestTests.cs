using Microsoft.VisualStudio.TestTools.UnitTesting;

#if !DEBUG
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel, Workers = 0)]
#endif
