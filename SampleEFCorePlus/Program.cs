using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SampleEFCorePlus.Models;

var options = new JsonSerializerOptions {
    ReferenceHandler = ReferenceHandler.IgnoreCycles
};

using var context = new FooContext();

var data = context.Foos
    .Include(x => x.Bar)
    .ThenInclude(x => x.FooBar)
    .ToList();

Console.WriteLine($"All data: {JsonSerializer.Serialize(data, options)}");

var byUserId = context.Foos.WhereDynamic(x => $"x.Id == 1").ToList();

Console.WriteLine();
Console.WriteLine($"Filtered bu User ID: {JsonSerializer.Serialize(byUserId, options)}");

var byArticleId = context.Foos.WhereDynamic(x => $"x.Bar.Id == 1").ToList();

Console.WriteLine();
Console.WriteLine($"Filtered by Article ID: {JsonSerializer.Serialize(byArticleId, options)}");

var byCommentId = context.Foos.WhereDynamic(x => $"x.Bar.FooBar.Id == 1").ToList();

Console.WriteLine();
Console.WriteLine($"Filtered Comment ID: {JsonSerializer.Serialize(byCommentId, options)}");