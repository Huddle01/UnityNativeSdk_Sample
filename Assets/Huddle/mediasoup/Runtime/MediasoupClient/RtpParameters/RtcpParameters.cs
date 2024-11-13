using Newtonsoft.Json;
using System;

namespace Mediasoup.RtpParameter {

    /// <summary>
    /// <para>Provides information on RTCP settings within the RTP parameters.</para>
    /// <para>
    /// If no cname is given in a producer's RTP parameters, the mediasoup transport
    /// will choose a random one that will be used into RTCP SDES messages sent to
    /// all its associated consumers.
    /// </para>
    /// <para>mediasoup assumes reducedSize to always be true.</para>
    /// </summary>
    [Serializable]
    public class RtcpParameters
    {
        /// <summary>
        /// The Canonical Name (CNAME) used by RTCP (e.g. in SDES messages).
        /// </summary>
        [JsonProperty("cname")]
        public string? CNAME { get; set; }

        /// <summary>
        /// Whether reduced size RTCP RFC 5506 is configured (if true) or compound RTCP
        /// as specified in RFC 3550 (if false). Default true.
        /// </summary>
        [JsonProperty("reducedSize")]
        public bool? ReducedSize { get; set; } = true;
    }
}
