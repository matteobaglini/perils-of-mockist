﻿using System;

namespace AccessControl.App
{
    public class AccessControlService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IDisplay display;

        public AccessControlService(IAccountRepository accountRepository, IDisplay display)
        {
            this.accountRepository = accountRepository;
            this.display = display;
        }

        public void Check(String accountId, String gateId)
        {
            var account = accountRepository.Load(accountId);
            display.ShowWelcomeMessage(account.Name);
        }
    }
}