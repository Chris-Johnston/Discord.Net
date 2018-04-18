namespace Discord
{
    /// <summary>
    ///     Properties that are used to modify an <see cref="IUserMessage" /> with the specified changes.
    /// </summary>
    /// <remarks>
    ///     The content of a message can be cleared with String.Empty; if and only if an Embed is present.
    /// </remarks>
    /// <example>
    ///     <code lang="c#">
    ///         var message = await ReplyAsync("abc");
    ///         await message.ModifyAsync(x =&gt;
    ///         {
    ///             x.Content = "";
    ///             x.Embed = new EmbedBuilder()
    ///                 .WithColor(new Color(40, 40, 120))
    ///                 .WithAuthor(a =&gt; a.Name = "foxbot")
    ///                 .WithTitle("Embed!")
    ///                 .WithDescription("This is an embed.");
    ///         });
    ///     </code>
    /// </example>
    public class MessageProperties
    {
        /// <summary>
        ///     Gets or sets the content of the message.
        /// </summary>
        /// <remarks>
        ///     This must be less than 2000 characters.
        /// </remarks>
        public Optional<string> Content { get; set; }
        /// <summary>
        ///     Gets or sets the embed the message should display.
        /// </summary>
        public Optional<Embed> Embed { get; set; }
    }
}
