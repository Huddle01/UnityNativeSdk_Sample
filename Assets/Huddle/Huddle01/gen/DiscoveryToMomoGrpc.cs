// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: node/discoveryToMomo.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace DiscoveryToMomo {
  public static partial class DiscoveryToMomo
  {
    static readonly string __ServiceName = "DiscoveryToMomo.DiscoveryToMomo";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.PongMomo> __Marshaller_DiscoveryToMomo_PongMomo = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.PongMomo.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.MomoStatus> __Marshaller_DiscoveryToMomo_MomoStatus = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.MomoStatus.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CreatePipeTransportRequest> __Marshaller_CreatePipeTransportRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CreatePipeTransportRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CreatePipeTransportResponse> __Marshaller_CreatePipeTransportResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CreatePipeTransportResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ConnectPipeTransportRequest> __Marshaller_ConnectPipeTransportRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ConnectPipeTransportRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ConnectPipeTransportResponse> __Marshaller_ConnectPipeTransportResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ConnectPipeTransportResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.MonitorChallengeRequest> __Marshaller_DiscoveryToMomo_MonitorChallengeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.MonitorChallengeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.MonitorChallengeResponse> __Marshaller_DiscoveryToMomo_MonitorChallengeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.MonitorChallengeResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.SendChallengeRequest> __Marshaller_DiscoveryToMomo_SendChallengeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.SendChallengeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.SendChallengeResponse> __Marshaller_DiscoveryToMomo_SendChallengeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.SendChallengeResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.StopChallengeRequest> __Marshaller_DiscoveryToMomo_StopChallengeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.StopChallengeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::DiscoveryToMomo.StopChallengeResponse> __Marshaller_DiscoveryToMomo_StopChallengeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::DiscoveryToMomo.StopChallengeResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.PongMomo> __Method_pingMomo = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.PongMomo>(
        grpc::MethodType.Unary,
        __ServiceName,
        "pingMomo",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_DiscoveryToMomo_PongMomo);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.MomoStatus> __Method_getMomoStatus = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.MomoStatus>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getMomoStatus",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_DiscoveryToMomo_MomoStatus);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CreatePipeTransportRequest, global::CreatePipeTransportResponse> __Method_createPipeTransport = new grpc::Method<global::CreatePipeTransportRequest, global::CreatePipeTransportResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "createPipeTransport",
        __Marshaller_CreatePipeTransportRequest,
        __Marshaller_CreatePipeTransportResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ConnectPipeTransportRequest, global::ConnectPipeTransportResponse> __Method_connectPipeTransport = new grpc::Method<global::ConnectPipeTransportRequest, global::ConnectPipeTransportResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "connectPipeTransport",
        __Marshaller_ConnectPipeTransportRequest,
        __Marshaller_ConnectPipeTransportResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::DiscoveryToMomo.MonitorChallengeRequest, global::DiscoveryToMomo.MonitorChallengeResponse> __Method_monitorChallenge = new grpc::Method<global::DiscoveryToMomo.MonitorChallengeRequest, global::DiscoveryToMomo.MonitorChallengeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "monitorChallenge",
        __Marshaller_DiscoveryToMomo_MonitorChallengeRequest,
        __Marshaller_DiscoveryToMomo_MonitorChallengeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::DiscoveryToMomo.SendChallengeRequest, global::DiscoveryToMomo.SendChallengeResponse> __Method_sendChallenge = new grpc::Method<global::DiscoveryToMomo.SendChallengeRequest, global::DiscoveryToMomo.SendChallengeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "sendChallenge",
        __Marshaller_DiscoveryToMomo_SendChallengeRequest,
        __Marshaller_DiscoveryToMomo_SendChallengeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::DiscoveryToMomo.StopChallengeRequest, global::DiscoveryToMomo.StopChallengeResponse> __Method_stopChallenge = new grpc::Method<global::DiscoveryToMomo.StopChallengeRequest, global::DiscoveryToMomo.StopChallengeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "stopChallenge",
        __Marshaller_DiscoveryToMomo_StopChallengeRequest,
        __Marshaller_DiscoveryToMomo_StopChallengeResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::DiscoveryToMomo.DiscoveryToMomoReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DiscoveryToMomo</summary>
    [grpc::BindServiceMethod(typeof(DiscoveryToMomo), "BindService")]
    public abstract partial class DiscoveryToMomoBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::DiscoveryToMomo.PongMomo> pingMomo(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::DiscoveryToMomo.MomoStatus> getMomoStatus(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Huddle01 QoS Protocol
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CreatePipeTransportResponse> createPipeTransport(global::CreatePipeTransportRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ConnectPipeTransportResponse> connectPipeTransport(global::ConnectPipeTransportRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::DiscoveryToMomo.MonitorChallengeResponse> monitorChallenge(global::DiscoveryToMomo.MonitorChallengeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::DiscoveryToMomo.SendChallengeResponse> sendChallenge(global::DiscoveryToMomo.SendChallengeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::DiscoveryToMomo.StopChallengeResponse> stopChallenge(global::DiscoveryToMomo.StopChallengeRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for DiscoveryToMomo</summary>
    public partial class DiscoveryToMomoClient : grpc::ClientBase<DiscoveryToMomoClient>
    {
      /// <summary>Creates a new client for DiscoveryToMomo</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public DiscoveryToMomoClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for DiscoveryToMomo that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public DiscoveryToMomoClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected DiscoveryToMomoClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected DiscoveryToMomoClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.PongMomo pingMomo(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return pingMomo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.PongMomo pingMomo(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_pingMomo, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.PongMomo> pingMomoAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return pingMomoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.PongMomo> pingMomoAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_pingMomo, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.MomoStatus getMomoStatus(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getMomoStatus(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.MomoStatus getMomoStatus(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getMomoStatus, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.MomoStatus> getMomoStatusAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getMomoStatusAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.MomoStatus> getMomoStatusAsync(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getMomoStatus, null, options, request);
      }
      /// <summary>
      /// Huddle01 QoS Protocol
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CreatePipeTransportResponse createPipeTransport(global::CreatePipeTransportRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return createPipeTransport(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Huddle01 QoS Protocol
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CreatePipeTransportResponse createPipeTransport(global::CreatePipeTransportRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_createPipeTransport, null, options, request);
      }
      /// <summary>
      /// Huddle01 QoS Protocol
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CreatePipeTransportResponse> createPipeTransportAsync(global::CreatePipeTransportRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return createPipeTransportAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Huddle01 QoS Protocol
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CreatePipeTransportResponse> createPipeTransportAsync(global::CreatePipeTransportRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_createPipeTransport, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ConnectPipeTransportResponse connectPipeTransport(global::ConnectPipeTransportRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return connectPipeTransport(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::ConnectPipeTransportResponse connectPipeTransport(global::ConnectPipeTransportRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_connectPipeTransport, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ConnectPipeTransportResponse> connectPipeTransportAsync(global::ConnectPipeTransportRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return connectPipeTransportAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::ConnectPipeTransportResponse> connectPipeTransportAsync(global::ConnectPipeTransportRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_connectPipeTransport, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.MonitorChallengeResponse monitorChallenge(global::DiscoveryToMomo.MonitorChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return monitorChallenge(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.MonitorChallengeResponse monitorChallenge(global::DiscoveryToMomo.MonitorChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_monitorChallenge, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.MonitorChallengeResponse> monitorChallengeAsync(global::DiscoveryToMomo.MonitorChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return monitorChallengeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.MonitorChallengeResponse> monitorChallengeAsync(global::DiscoveryToMomo.MonitorChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_monitorChallenge, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.SendChallengeResponse sendChallenge(global::DiscoveryToMomo.SendChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return sendChallenge(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.SendChallengeResponse sendChallenge(global::DiscoveryToMomo.SendChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_sendChallenge, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.SendChallengeResponse> sendChallengeAsync(global::DiscoveryToMomo.SendChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return sendChallengeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.SendChallengeResponse> sendChallengeAsync(global::DiscoveryToMomo.SendChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_sendChallenge, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.StopChallengeResponse stopChallenge(global::DiscoveryToMomo.StopChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return stopChallenge(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::DiscoveryToMomo.StopChallengeResponse stopChallenge(global::DiscoveryToMomo.StopChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_stopChallenge, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.StopChallengeResponse> stopChallengeAsync(global::DiscoveryToMomo.StopChallengeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return stopChallengeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::DiscoveryToMomo.StopChallengeResponse> stopChallengeAsync(global::DiscoveryToMomo.StopChallengeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_stopChallenge, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override DiscoveryToMomoClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new DiscoveryToMomoClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(DiscoveryToMomoBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_pingMomo, serviceImpl.pingMomo)
          .AddMethod(__Method_getMomoStatus, serviceImpl.getMomoStatus)
          .AddMethod(__Method_createPipeTransport, serviceImpl.createPipeTransport)
          .AddMethod(__Method_connectPipeTransport, serviceImpl.connectPipeTransport)
          .AddMethod(__Method_monitorChallenge, serviceImpl.monitorChallenge)
          .AddMethod(__Method_sendChallenge, serviceImpl.sendChallenge)
          .AddMethod(__Method_stopChallenge, serviceImpl.stopChallenge).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, DiscoveryToMomoBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_pingMomo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.PongMomo>(serviceImpl.pingMomo));
      serviceBinder.AddMethod(__Method_getMomoStatus, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::DiscoveryToMomo.MomoStatus>(serviceImpl.getMomoStatus));
      serviceBinder.AddMethod(__Method_createPipeTransport, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CreatePipeTransportRequest, global::CreatePipeTransportResponse>(serviceImpl.createPipeTransport));
      serviceBinder.AddMethod(__Method_connectPipeTransport, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ConnectPipeTransportRequest, global::ConnectPipeTransportResponse>(serviceImpl.connectPipeTransport));
      serviceBinder.AddMethod(__Method_monitorChallenge, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::DiscoveryToMomo.MonitorChallengeRequest, global::DiscoveryToMomo.MonitorChallengeResponse>(serviceImpl.monitorChallenge));
      serviceBinder.AddMethod(__Method_sendChallenge, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::DiscoveryToMomo.SendChallengeRequest, global::DiscoveryToMomo.SendChallengeResponse>(serviceImpl.sendChallenge));
      serviceBinder.AddMethod(__Method_stopChallenge, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::DiscoveryToMomo.StopChallengeRequest, global::DiscoveryToMomo.StopChallengeResponse>(serviceImpl.stopChallenge));
    }

  }
}
#endregion
