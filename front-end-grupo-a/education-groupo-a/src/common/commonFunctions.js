  var validations = {
    validateName: function (name) {
        if (name.length <= 1)
            return 'The name must be grather than 1 caracter';
    
        return true; 
    },

    validateCpf: function(cpf) {
        cpf = cpf.replace(/\D/g, '');
        
        if(cpf.toString().length != 11 || /^(\d)\1{10}$/.test(cpf)) 
            return `CPF must have at least 11 characters, the ${cpf} has only ${cpf.length}`;

        var result = true;
        [9,10].forEach(function(j){
            var soma = 0, r;
            cpf.split(/(?=)/).splice(0,j).forEach(function(e, i){
                soma += parseInt(e) * ((j+2)-(i+1));
            });
            r = soma % 11;
            r = (r <2)?0:11-r;
            if(r != cpf.substring(j, j+1)) result = false;
        });        
            
        if (!result)
            return `CPF ${cpf} is invalid`;
        else     
            return true;
    },
    
    validateMail: function(mail) {
        var mailRegexValidation = /\S+@\S+\.\S+/;
        var mailValidateResult = mailRegexValidation.test(mail);

        if (!mailValidateResult)
            return `Mail ${mail} is not valid`;

        return mailValidateResult;
    }    
  }

  export default {
    validations
  };