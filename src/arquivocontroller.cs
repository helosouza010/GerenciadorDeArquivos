using GerenciadorDeArquivos;
using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;

public class ArquivoController : Controller
{
    FileManager fileManager = new FileManager();

    [HttpPost]
    public IActionResult CriarArquivo()
    {
        fileManager.CreateFile("novoArquivo.txt");
        ViewBag.Mensagem = "Arquivo criado com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult LerArquivo()
    {
        var conteudo = fileManager.ReadFromFile("novoArquivo.txt");
        ViewBag.Conteudo = conteudo;
        return View("Index");
    }

    [HttpPost]
    public IActionResult EscreverArquivo()
    {
        fileManager.WriteToFile("novoArquivo.txt", "Conteúdo de exemplo.");
        ViewBag.Mensagem = "Conteúdo escrito com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult RenomearArquivo()
    {
        fileManager.RenameFile("novoArquivo.txt", "arquivoRenomeado.txt");
        ViewBag.Mensagem = "Arquivo renomeado com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult CopiarArquivo()
    {
        fileManager.CopyFile("arquivoRenomeado.txt", "arquivoCopiado.txt");
        ViewBag.Mensagem = "Arquivo copiado com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult DeletarArquivo()
    {
        fileManager.DeleteFile("arquivoCopiado.txt");
        ViewBag.Mensagem = "Arquivo deletado com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult ExibirInfoArquivo()
    {
        fileManager.DisplayFileInfo("exibirinfoArquivo.txt");
        return View("Index");
    }

    [HttpPost]
    public IActionResult ListarArquivosDoDiretorio()
    {
        fileManager.CloseFile("arquivoRenomeado.txt");
        ViewBag.Mensagem = "Arquivo listado com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult ModificarAtributos()
    {
        fileManager.ModifyAtributes("arquivoRenomeado.txt", FileAttributes.ReadOnly);
        ViewBag.Mensagem = "Atributos modificados com sucesso!";
        return View("Index");
    }

    [HttpPost]
    public IActionResult Sair()
    {
        var conteudo = fileManager.ReadFromFile("novoArquivo.txt"); // Ajustado para ler um arquivo válido
        ViewBag.Conteudo = conteudo;
        return View("Index");
    }
}
