﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System.IO.Compression;

namespace MDF.Framework.Middlewares;
/// <summary>
/// Compress responses to reduce bandwidth usage.
/// </summary>
public class ResponseCompressionMiddleware
{
	private readonly RequestDelegate _next;
	public ResponseCompressionMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task Invoke(HttpContext context)
	{
		// Check if client supports compression
		if (context.Request.Headers["Accept-Encoding"].Contains("gzip"))
		{
			// Stream to hold compressed response
			MemoryStream compressedStream = new MemoryStream();
			// Compress stream
			using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Compress))
			{
				await _next(context);
				context.Response.Body.CopyTo(gzipStream);
			}
			// Replace uncompressed response with compressed one
			context.Response.Body = compressedStream;
			// Header to indicate compressed response
			context.Response.Headers.Add("Content-Encoding", "gzip");
		}
		else
		{
			await _next(context);
		}
	}
}
public static class ResponseCompressionMiddlewareExtensions
{
	public static IApplicationBuilder UseResponseCompressionMiddleware(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<ResponseCompressionMiddleware>();
	}
}