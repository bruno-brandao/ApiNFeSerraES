using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnclePhill.WebAPI_NFeS.WS.Models
{
    public class NFeS
    {
        public NFeS()
        {

        }

        public NFeS(int NFeSId, int TakerId, 
            string DateEmission, string RPS, 
            string DateEmissionRPS, string ServicesProvied, 
            string LocalService, string Note, 
            decimal TaxWithheld, decimal TotalISS,
            decimal TotalCONFIS, decimal TotalCSLL,
            decimal TotalOther, decimal TotalServices,
            decimal ValueDeductions, decimal TotalNFeS,
            bool Active, string DateInsert, string DateUpdate,
            List<NFeSItens> Itens, List<NFeSInvoices> Invoices)
        {
            this.NFeSId = NFeSId;
            this.TakerId = TakerId;
            this.DateEmission = DateEmission;
            this.RPS = RPS;
            this.DateEmissionRPS = DateEmissionRPS;
            this.ServicesProvied = ServicesProvied;
            this.LocalService = LocalService;
            this.Note = Note;
            this.TaxWithheld = TaxWithheld;
            this.TotalISS = TotalISS;
            this.TotalIRRF = TotalIRRF;
            this.TotalPIS = TotalPIS;
            this.TotalINSS = TotalINSS;
            this.TotalCONFIS = TotalCONFIS;
            this.TotalCSLL = TotalCSLL;
            this.TotalOther = TotalOther;
            this.TotalServices = TotalServices;
            this.ValueDeductions = ValueDeductions;
            this.TotalNFeS = TotalNFeS;
            this.Active = Active;
            this.DateInsert = DateInsert;
            this.DateUpdate = DateUpdate;
            this.Itens = Itens;
            this.Invoices = Invoices;
        }

        public int NFeSId { get; set; }
        public int TakerId { get; set; }
        public string DateEmission { get; set; }
        public string RPS { get; set; }
        public string DateEmissionRPS { get; set; }
        public string ServicesProvied { get; set; }
        public string LocalService { get; set; }
        public string Note { get; set; }
        public decimal TaxWithheld { get; set; }
        public decimal TotalISS { get; set; }
        public decimal TotalIRRF { get; set; }
        public decimal TotalPIS { get; set; }
        public decimal TotalINSS { get; set; }
        public decimal TotalCONFIS { get; set; }
        public decimal TotalCSLL { get; set; }
        public decimal TotalOther { get; set; }
        public decimal TotalServices { get; set; }
        public decimal ValueDeductions { get; set; }
        public decimal TotalNFeS { get; set; }        
        public bool Active { get; set; }
        public string DateInsert { get; set; }
        public string DateUpdate { get; set; }
        public List<NFeSItens> Itens { get; set; }
        public List<NFeSInvoices> Invoices { get; set; }
    }
}