package com.example.internetshopserver.payment;

import com.example.internetshopserver.common.ApplicationProperties;
import lombok.AllArgsConstructor;
import org.springframework.boot.web.client.RestTemplateBuilder;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

import java.util.Objects;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.PAYMENT_API_URL)
public class PaymentController {

    private final RestTemplateBuilder builder;

    @PutMapping("/{number}")
    public void payPurchase(@PathVariable(value = "number") String accountNumber,
                                      @RequestBody AccountDTO accountDTO) {
        RestTemplate restTemplate = builder.build();
        restTemplate.put("http://localhost:9074/api/accounts/bynumber/" + accountNumber, accountDTO);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(org.springframework.web.client.HttpClientErrorException.class)
    public String handleValidationExceptions(org.springframework.web.client.HttpClientErrorException ex) {
        return Objects.requireNonNull(ex.getMessage()).substring(ex.getMessage().indexOf('[') + 1, ex.getMessage().length() - 1);
    }

}
