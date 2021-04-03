package com.example.internetshopserver.config;

import com.example.internetshopserver.authinfo.AuthInfo;
import com.example.internetshopserver.authinfo.AuthInfoDTO;
import com.example.internetshopserver.authinfo.AuthInfoMapper;
import com.example.internetshopserver.common.ApplicationProperties;
import com.example.internetshopserver.config.jwt.JwtFilter;
import lombok.AllArgsConstructor;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.access.AccessDeniedException;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.AuthenticationEntryPoint;
import org.springframework.security.web.access.AccessDeniedHandler;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;


import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;


@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true, securedEnabled = true, jsr250Enabled = true)
@AllArgsConstructor
public class SpringSecurityConfig extends WebSecurityConfigurerAdapter implements WebMvcConfigurer {

    private final AuthInfoMapper authInfoMapper;
    private final JwtFilter jwtFilter;

    @Bean
    public PasswordEncoder passwordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Override
    protected void configure(HttpSecurity http) throws Exception {
        http
                .cors()
                .and()
                .httpBasic().disable()
                .csrf().disable()
                .sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS)
                .and()
                .authorizeRequests()
                .antMatchers(ApplicationProperties.API_URL + "/ingredients/**").hasRole("user")
                .antMatchers(ApplicationProperties.API_URL + "/ingredients/byCodes/").permitAll()
                .antMatchers(ApplicationProperties.API_URL + "/cartItems/**").hasRole("user")
                .antMatchers(ApplicationProperties.API_URL + "/payment/**").hasRole("user")
                .anyRequest().authenticated()
                .and()
                .exceptionHandling()
                .accessDeniedHandler(accessDeniedHandler())
                .authenticationEntryPoint(authenticationEntryPoint())
                .and()
                .addFilterBefore(jwtFilter, UsernamePasswordAuthenticationFilter.class);
    }

    private AccessDeniedHandler accessDeniedHandler() {
        return new AccessDeniedHandler() {
            @Override
            public void handle(HttpServletRequest httpServletRequest,
                               HttpServletResponse httpServletResponse,
                               AccessDeniedException e) throws IOException {
                AuthInfoDTO authInfoDTO = authInfoMapper.toAuthInfoDTO(
                        AuthInfo.builder()
                                .status("error")
                                .code(403)
                                .details("Access denied")
                                .build()
                );
                httpServletResponse.setContentType("application/json");
                httpServletResponse.setCharacterEncoding("UTF-8");
                httpServletResponse.getWriter().append(authInfoDTO.getJson());
                httpServletResponse.setStatus(403);
            }
        };
    }

    private AuthenticationEntryPoint authenticationEntryPoint() {

        return new AuthenticationEntryPoint() {
            @Override
            public void commence(HttpServletRequest httpServletRequest,
                                 HttpServletResponse httpServletResponse,
                                 AuthenticationException e) throws IOException {
                AuthInfoDTO authInfoDTO = authInfoMapper.toAuthInfoDTO(
                        AuthInfo.builder()
                                .status("error")
                                .code(401)
                                .details("Not authenticated")
                                .build()
                );
                httpServletResponse.setContentType("application/json");
                httpServletResponse.setCharacterEncoding("UTF-8");
                httpServletResponse.getWriter().append(authInfoDTO.getJson());
                httpServletResponse.setStatus(401);
            }
        };
    }
}

