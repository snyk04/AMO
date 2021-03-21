package com.example.lab_1


import androidx.appcompat.app.AppCompatActivity
import android.content.Intent
import android.widget.Button
import android.os.Bundle


class InfoPage : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.info_page)

        configurePageButton()
    }

    private fun configurePageButton() {
        val goBackButton: Button = findViewById(R.id.goBackButton)

        goBackButton.setOnClickListener {
            val myIntent = Intent(this@InfoPage, Activity1::class.java)
            this@InfoPage.startActivity(myIntent)
        }
    }
}