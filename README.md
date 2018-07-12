# LambdaAOP
一个 用 C# 实现的 使用 Lambda 表达式 的 AOP


这是 一个 用 C# 实现的 使用 Lambda 表达式 的 AOP   。

用 Lambda 表达式 来 实现 AOP 这个 想法 来自于  Polly.Net  。

一开始 看到  Polly.Net 的 时候， 只看到 一堆  police.Handle() ,  police.Handle()  ,  police.Handle()   ……
police.ReTry()   ……

就没看到 在 哪里调用 要执行的 方法 ，   然后 就 觉得 ，   Polly.Net  这个 好像 AOP 啊 ， 而且 这个 AOP 有点牛 ，
有点 指哪打哪 的 意思 了  。  ^^

后来看到   police.Execute( () => DoSomething() )   ，  才 发现 ， 哦 ，  原来 是 通过  police.Execute( )  方法 执行 的 ，
而且 使用了  Lambda 表达式  。

所以 就 觉得  Lambda 表达式 很适合 来 实现 AOP ，  所以 就写 了 这个 项目 。

通过  LambdaAOP  ， 可以 让一个 普通对象 乃至于 静态方法  瞬间 拥有 AOP 特性 ， 也可以 瞬间 取消  。
即插即用 ，  即拔即停   ，    代码透明  ，   绿色 环保 无污染   。   ^^  ^^  ^^

这要 归功于  Lambda 表达式   在 语法 和 实现 上的 支持 。  实现 是指  System.Linq.Expressions  。

System.Reflection ,    System.Reflection.Emit     ,      System.Linq.Expressions   
这 3 者 是 关联 的  ，  但 有意思 的 是    Expressions  是 归到了 System.Linq    。

好了 不多说了 ，  用法 和 原理 看代码 吧 。  :)










