const markdownRegex = new RegExp("^\\s*", "gm");

window.toMarkdown = function (element) {
    const converter = new showdown.Converter({extensions: ['highlight']});
    const text = element.firstChild.value.replace(markdownRegex, "");    
    const html = converter.makeHtml(text);
    element.innerHTML = html;
}

hljs.initHighlightingOnLoad();

showdown.extension('highlight', function () {
    return [{
        type: "output",
        filter: function (text, converter, options) {
            var left = "<pre><code\\b[^>]*>",
                right = "</code></pre>",
                flags = "g";
            var replacement = function (wholeMatch, match, left, right) {
                var lang = (left.match(/class=\"([^ \"]+)/) || [])[1];
                left = left.slice(0, 18) + 'hljs ' + left.slice(18);
                if (lang && hljs.getLanguage(lang)) {
                    return left + hljs.highlight(lang, match).value + right;
                } else {
                    return left + hljs.highlightAuto(match).value + right;
                }
            };
            return showdown.helper.replaceRecursiveRegExp(text, replacement, left, right, flags);
        }
    }];
});