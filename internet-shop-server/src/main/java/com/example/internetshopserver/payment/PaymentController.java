package com.example.internetshopserver.payment;

import com.example.internetshopserver.common.ApplicationProperties;
import com.example.internetshopserver.config.jwt.JwtFilter;
import lombok.AllArgsConstructor;
import org.springframework.boot.web.client.RestTemplateBuilder;
import org.springframework.http.HttpStatus;
import org.springframework.http.client.ClientHttpRequestInterceptor;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.PAYMENT_API_URL)
public class PaymentController {

    private final RestTemplateBuilder builder;
    private final JwtFilter jwtFilter;

    @PutMapping("/{number}")
    public void payPurchase(@PathVariable(value = "number") String accountNumber,
                                      @RequestBody AccountDTO accountDTO,
                            HttpServletRequest request) {
        RestTemplate restTemplate = builder.build();
        List<ClientHttpRequestInterceptor> interceptors = new ArrayList<ClientHttpRequestInterceptor>();
        interceptors.add(new HeaderRequestInterceptor(
                "Authorization",
                "Bearer " + jwtFilter.getTokenFromRequest(request))
        );
        restTemplate.setInterceptors(interceptors);
        restTemplate.put("http://localhost:9074/api/accounts/bynumber/" + accountNumber, accountDTO);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(org.springframework.web.client.HttpClientErrorException.class)
    public String handleValidationExceptions(org.springframework.web.client.HttpClientErrorException ex) {
        return Objects.requireNonNull(ex.getMessage()).substring(ex.getMessage().indexOf('[') + 2, ex.getMessage().length() - 2);
    }

}
