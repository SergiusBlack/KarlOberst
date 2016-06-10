-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema karl_oberst
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema karl_oberst
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `karl_oberst` DEFAULT CHARACTER SET utf8 ;
USE `karl_oberst` ;

-- -----------------------------------------------------
-- Table `karl_oberst`.`direccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`direccion` (
  `id_direccion` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `direccion1` VARCHAR(400) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `ciudad` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `pais` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `cp` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id_direccion`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;


-- -----------------------------------------------------
-- Table `karl_oberst`.`role`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`role` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `descripcion` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;


-- -----------------------------------------------------
-- Table `karl_oberst`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`usuario` (
  `id_usuario` INT(11) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `email` VARCHAR(45) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `id_direccion` INT(11) NOT NULL,
  `role_id` INT(11) NOT NULL,
  PRIMARY KEY (`id_usuario`),
  CONSTRAINT `fk_usuario_direccion1`
    FOREIGN KEY (`id_direccion`)
    REFERENCES `karl_oberst`.`direccion` (`id_direccion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_role1`
    FOREIGN KEY (`role_id`)
    REFERENCES `karl_oberst`.`role` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;

CREATE INDEX `fk_usuario_direccion1_idx` ON `karl_oberst`.`usuario` (`id_direccion` ASC);

CREATE INDEX `fk_usuario_role1_idx` ON `karl_oberst`.`usuario` (`role_id` ASC);


-- -----------------------------------------------------
-- Table `karl_oberst`.`cart`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`cart` (
  `cart_id` INT(11) NOT NULL AUTO_INCREMENT,
  `subtotal` FLOAT NOT NULL,
  `iva` INT(2) NOT NULL,
  `total` FLOAT NOT NULL,
  `fecha` DATE NULL DEFAULT NULL,
  `id_usuario` INT(11) NOT NULL,
  PRIMARY KEY (`cart_id`),
  CONSTRAINT `fk_cart_usuario1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `karl_oberst`.`usuario` (`id_usuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;

CREATE INDEX `fk_cart_usuario1_idx` ON `karl_oberst`.`cart` (`id_usuario` ASC);


-- -----------------------------------------------------
-- Table `karl_oberst`.`genero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`genero` (
  `id_genero` INT(5) NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(40) CHARACTER SET 'utf8' NOT NULL,
  `descripcion` VARCHAR(500) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `img` VARCHAR(300) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`id_genero`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;


-- -----------------------------------------------------
-- Table `karl_oberst`.`producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`producto` (
  `id_product` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) CHARACTER SET 'latin1' NOT NULL,
  `description` VARCHAR(250) CHARACTER SET 'latin1' NOT NULL,
  `price` DECIMAL(6,2) NOT NULL,
  `url` VARCHAR(500) CHARACTER SET 'utf8' NOT NULL,
  `id_genero` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id_product`),
  CONSTRAINT `id_genero`
    FOREIGN KEY (`id_genero`)
    REFERENCES `karl_oberst`.`genero` (`id_genero`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;

CREATE INDEX `id_genero` ON `karl_oberst`.`producto` (`id_genero` ASC);


-- -----------------------------------------------------
-- Table `karl_oberst`.`item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `karl_oberst`.`item` (
  `id_item` INT(11) NOT NULL AUTO_INCREMENT,
  `cantidad` INT(11) NULL DEFAULT NULL,
  `cart_id` INT(11) NOT NULL,
  `id_producto` INT(11) NOT NULL,
  PRIMARY KEY (`id_item`),
  CONSTRAINT `fk_item_cart1`
    FOREIGN KEY (`cart_id`)
    REFERENCES `karl_oberst`.`cart` (`cart_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_item_producto1`
    FOREIGN KEY (`id_producto`)
    REFERENCES `karl_oberst`.`producto` (`id_product`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_spanish_ci;

CREATE INDEX `fk_item_cart1_idx` ON `karl_oberst`.`item` (`cart_id` ASC);

CREATE INDEX `fk_item_producto1_idx` ON `karl_oberst`.`item` (`id_producto` ASC);


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
