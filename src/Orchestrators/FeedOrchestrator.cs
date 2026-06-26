using System.Text;
using System.Text.RegularExpressions;
using XPoster.Abstraction;
using XPoster.Contracts;
using XPoster.Models;

namespace XPoster.Orchestrators;

/// <summary>
/// Orchestrates a social-media post by aggregating Bitcoin-related RSS news from the last 24 hours,
/// summarising the content via AI, and optionally attaching an AI-generated image.
/// Implements a fan-out pattern: the base summary and image are generated once from the primary sender
/// (index 0, widest <c>MessageMaxLength</c>), then each secondary sender receives an AI re-summarisation
/// only when the base summary exceeds its limit. Hashtag substitution is applied independently per sender.
/// Returns an <see cref="IReadOnlyDictionary{SenderPlatform,Post}"/> keyed by <see cref="ISender.Platform"/>
/// for unambiguous n