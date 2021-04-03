package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.ingredient.Ingredient;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import javax.persistence.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "cart_item", uniqueConstraints=@UniqueConstraint(columnNames={"ingredient_id", "cart_item_username"}))
public class CartItem {

    @Id
    @GeneratedValue
    @Column(name = "id", nullable = false)
    private Long id;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "ingredient_id", nullable = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    private Ingredient ingredient;

    @Column(name = "cart_item_count", nullable = false)
    private Integer cartItemCount;

    @Column(name = "cart_item_username", nullable = false)
    private String cartItemUserName;

}
