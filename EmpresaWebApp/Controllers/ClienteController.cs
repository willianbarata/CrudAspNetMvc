﻿using EmpresaData.DAO;
using EmpresaData.DTO;
using EmpresaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaWebApp.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDao clienteDao;
        Cliente clienteDto;

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel clienteVM)
        {
            if (ModelState.IsValid)
            {
                clienteDao = new ClienteDao();
                clienteDto = new Cliente();

                clienteDto.ClienteId = clienteVM.ClienteId;
                clienteDto.Nome = clienteVM.Nome;
                clienteDto.CPF = clienteVM.CPF;
                clienteDto.Idade = clienteVM.Idade;

                clienteDao.IncluiCliente(clienteDto);

                return RedirectToAction("ListarCliente", "Cliente");
            }

            return View();
        }

        [HttpGet]
        public IActionResult ListarCliente()
        {
            clienteDao = new ClienteDao();
            clienteDto = new Cliente();

            List<ClienteViewModel> lista = new List<ClienteViewModel>();

            List<Cliente> listaDto = new List<Cliente>();

            listaDto = clienteDao.ListarClientes();

            foreach(Cliente cliente in listaDto)
            {
                ClienteViewModel clienteVM = new ClienteViewModel();
                clienteVM.ClienteId = cliente.ClienteId;
                clienteVM.Nome = cliente.Nome;
                clienteVM.CPF = cliente.CPF;
                clienteVM.Idade = cliente.Idade;

                lista.Add(clienteVM);
            }
            return View(lista);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            clienteDao = new ClienteDao();
            clienteDto = new Cliente();

            clienteDto = clienteDao.ObtemCliente(id);

            ClienteViewModel clienteVM = new ClienteViewModel();
            clienteVM.ClienteId = clienteDto.ClienteId;
            clienteVM.Nome = clienteDto.Nome;
            clienteVM.CPF = clienteDto.CPF;
            clienteVM.Idade = clienteDto.Idade;

            return View(clienteVM);
        }

    
        public IActionResult Edit(ClienteViewModel clienteVM)
        {
            clienteDao = new ClienteDao();
            clienteDto = new Cliente();

            clienteDto.ClienteId = clienteVM.ClienteId;
            clienteDto.Nome = clienteVM.Nome;
            clienteDto.CPF = clienteVM.CPF;
            clienteDto.Idade = clienteVM.Idade;

            clienteDao.AlterarCliente(clienteDto);

            return RedirectToAction("ListarCliente", "Cliente");
        }

        public IActionResult Delete(int id)
        {
            clienteDao = new ClienteDao();
            clienteDao.ExcluirCliente(id);
            return RedirectToAction("ListarCliente", "Cliente");

        }

      
      


    }
}
